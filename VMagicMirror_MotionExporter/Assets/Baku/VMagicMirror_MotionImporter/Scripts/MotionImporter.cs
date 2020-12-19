using System;
using System.Collections.Generic;
using UnityEngine;

namespace Baku.VMagicMirror.MotionExporter
{
    /// <summary> 文字列化されたモーションデータをランタイムでAnimationClipに戻す処理の実装</summary>
    public class MotionImporter
    {
        /// <summary> クリップのロード処理が失敗すると例外メッセージを引数にして発火 </summary>
        public event Action<string> LoadError;

        //NOTE: Exceptionベースにしてもさほど嬉しくないのでエラーイベントを作り、このメソッド自体は例外をスローしません
        /// <summary>
        /// JSON文字列を指定してアニメーションクリップをロードします。
        /// ロードに失敗するとnullを返しつつ、<see cref="LoadError"/>イベントに詳細を送信します。
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public AnimationClip Deserialize(string json)
        {
            try
            {
                var motion = JsonUtility.FromJson<SerializedMotion>(json);
                return DeserializeToClip(motion);
            }
            catch (Exception ex)
            {
                LoadError?.Invoke(ex.Message);
                return null;
            }
        }

        public SerializedMotion LoadSerializedMotion(string json)
        {
            try
            {
                return JsonUtility.FromJson<SerializedMotion>(json);
            }
            catch (Exception ex)
            {
                LoadError?.Invoke(ex.Message);
                return null;
            }            
        }

        public AnimationClip Deserialize(SerializedMotion motion) => DeserializeToClip(motion);

        private static AnimationClip DeserializeToClip(SerializedMotion motion)
        {
            //NOTE: このAnimationClip自体はLegacy Animationになり、
            //HumanoidAnimationSetterに対して姿勢情報を書き込めるようになるので、
            //書き込ませた姿勢情報をコピーすればアニメーションが動かせる、という筋立て
            var result = new AnimationClip();
            foreach (var binding in motion.curveBindings)
            {
                result.SetCurve(binding.path, typeof(HumanoidAnimationSetter), binding.propertyName, DeserializeToCurve(binding.curve));
            }
            return result;
        }

        private static AnimationCurve DeserializeToCurve(SerializedMotionCurve curve)
        {
            var result = new AnimationCurve
            {
                preWrapMode = WrapMode.Clamp,
                postWrapMode = WrapMode.Clamp,
            };

            var keyframes = DeserializeKeyFrames(curve.b64KeyFrames);
            foreach (var keyFrame in keyframes)
            {
                result.AddKey(DeserializeToKeyFrame(keyFrame));                
            }
            return result;
        }

        private static List<SerializedMotionKeyFrame> DeserializeKeyFrames(string b64keyFrames)
        {
            var result = new List<SerializedMotionKeyFrame>();
            var bytes = Convert.FromBase64String(b64keyFrames);
            //ブロックごとに読み取っていくのでこんなかんじ。
            //NOTE: ここはバージョン差があると読み込みがトラブりやすい場所なので注意！
            for (int i = 0; i + SerializedMotionKeyFrame.BinaryCount <= bytes.Length; i+= SerializedMotionKeyFrame.BinaryCount)
            {
                result.Add(ReadFromBytes(bytes, i));
            }
            return result;
        }

        private static SerializedMotionKeyFrame ReadFromBytes(byte[] bytes, int index)
        {
            return new SerializedMotionKeyFrame()
            {
                time = BitConverter.ToSingle(bytes, index),
                value = BitConverter.ToSingle(bytes, index + 4),
                inTangent = BitConverter.ToSingle(bytes, index + 8),
                inWeight = BitConverter.ToSingle(bytes, index + 12),
                outTangent = BitConverter.ToSingle(bytes, index + 16),
                outWeight = BitConverter.ToSingle(bytes, index + 20),
                weightedMode = BitConverter.ToInt32(bytes, index + 24),
            };
        }

        
        private static Keyframe DeserializeToKeyFrame(SerializedMotionKeyFrame keyFrame)
        {
            return new Keyframe(
                keyFrame.time, 
                keyFrame.value,
                keyFrame.inTangent, 
                keyFrame.outTangent,
                keyFrame.inWeight,
                keyFrame.outWeight
            )
            {
                weightedMode = SerializeKeyframeParams.GetWeighedMode(keyFrame.weightedMode)
            };
        }
    }
}
