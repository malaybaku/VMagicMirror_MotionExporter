using UnityEngine;

namespace Baku.VMagicMirror.MotionExporter
{
    
    /// <summary>
    /// Humanoid Animationのパラメータをフィールドで受け取るクラス。
    /// </summary>
    public class HumanoidAnimationSetter : MonoBehaviour
    {
        #region マッスルのパラメータをそのまんま受けるやつ
        
        public float p0;
        public float p1;
        public float p2;
        public float p3;
        public float p4;
        public float p5;
        public float p6;
        public float p7;
        public float p8;
        public float p9;
        
        public float p10;
        public float p11;
        public float p12;
        public float p13;
        public float p14;
        public float p15;
        public float p16;
        public float p17;
        public float p18;
        public float p19;
        
        public float p20;
        public float p21;
        public float p22;
        public float p23;
        public float p24;
        public float p25;
        public float p26;
        public float p27;
        public float p28;
        public float p29;
        
        public float p30;
        public float p31;
        public float p32;
        public float p33;
        public float p34;
        public float p35;
        public float p36;
        public float p37;
        public float p38;
        public float p39;
        
        public float p40;
        public float p41;
        public float p42;
        public float p43;
        public float p44;
        public float p45;
        public float p46;
        public float p47;
        public float p48;
        public float p49;
        
        public float p50;
        public float p51;
        public float p52;
        public float p53;
        public float p54;
        public float p55;
        public float p56;
        public float p57;
        public float p58;
        public float p59;
        
        public float p60;
        public float p61;
        public float p62;
        public float p63;
        public float p64;
        public float p65;
        public float p66;
        public float p67;
        public float p68;
        public float p69;

        public float p70;
        public float p71;
        public float p72;
        public float p73;
        public float p74;
        public float p75;
        public float p76;
        public float p77;
        public float p78;
        public float p79;
        
        public float p80;
        public float p81;
        public float p82;
        public float p83;
        public float p84;
        public float p85;
        public float p86;
        public float p87;
        public float p88;
        public float p89;
        public float p90;
        
        public float p91;
        public float p92;
        public float p93;
        public float p94;

        #endregion

        #region IK系のパラメータ
        
        //NOTE: 現行実装では活用できてないパラメータですが、データ上は存在するはずなので今のうちから用意しています
        
        public Vector3 RootT;
        public Quaternion RootQ;

        public Vector3 MotionT;
        public Quaternion MotionQ;

        public Vector3 LeftFootT;
        public Quaternion LeftFootQ;
        public Vector3 RightFootT;
        public Quaternion RightFootQ;

        public Vector3 LeftHandT;
        public Quaternion LeftHandQ;
        public Vector3 RightHandT;
        public Quaternion RightHandQ;

        #endregion
        
        private readonly float[] _muscleArray = new float[95];
        private readonly bool[] _usedMuscleFlags = new bool[95];

        /// <summary>
        /// マッスル配列に直接アクセスします。通常は使わないほうがいいです。
        /// </summary>
        /// <returns></returns>
        public float[] GetMuscleArrayReference() => _muscleArray;

        /// <summary>
        /// 内部的にプロパティ値を配列に転写します。WriteToPoseする前に一回呼ぶ必要があります。
        /// </summary>
        /// <remarks>
        /// ほんとは不要な処理ですが、やらないとコードが難しい事になるのでやってます
        /// </remarks>
        public void WriteToArray()
        {
            _muscleArray[0] = p0;
            _muscleArray[1] = p1;
            _muscleArray[2] = p2;
            _muscleArray[3] = p3;
            _muscleArray[4] = p4;
            _muscleArray[5] = p5;
            _muscleArray[6] = p6;
            _muscleArray[7] = p7;
            _muscleArray[8] = p8;
            _muscleArray[9] = p9;

            _muscleArray[10] = p10;
            _muscleArray[11] = p11;
            _muscleArray[12] = p12;
            _muscleArray[13] = p13;
            _muscleArray[14] = p14;
            _muscleArray[15] = p15;
            _muscleArray[16] = p16;
            _muscleArray[17] = p17;
            _muscleArray[18] = p18;
            _muscleArray[19] = p19;

            _muscleArray[20] = p20;
            _muscleArray[21] = p21;
            _muscleArray[22] = p22;
            _muscleArray[23] = p23;
            _muscleArray[24] = p24;
            _muscleArray[25] = p25;
            _muscleArray[26] = p26;
            _muscleArray[27] = p27;
            _muscleArray[28] = p28;
            _muscleArray[29] = p29;

            _muscleArray[30] = p30;
            _muscleArray[31] = p31;
            _muscleArray[32] = p32;
            _muscleArray[33] = p33;
            _muscleArray[34] = p34;
            _muscleArray[35] = p35;
            _muscleArray[36] = p36;
            _muscleArray[37] = p37;
            _muscleArray[38] = p38;
            _muscleArray[39] = p39;

            _muscleArray[40] = p40;
            _muscleArray[41] = p41;
            _muscleArray[42] = p42;
            _muscleArray[43] = p43;
            _muscleArray[44] = p44;
            _muscleArray[45] = p45;
            _muscleArray[46] = p46;
            _muscleArray[47] = p47;
            _muscleArray[48] = p48;
            _muscleArray[49] = p49;

            _muscleArray[50] = p50;
            _muscleArray[51] = p51;
            _muscleArray[52] = p52;
            _muscleArray[53] = p53;
            _muscleArray[54] = p54;
            _muscleArray[55] = p55;
            _muscleArray[56] = p56;
            _muscleArray[57] = p57;
            _muscleArray[58] = p58;
            _muscleArray[59] = p59;

            _muscleArray[60] = p60;
            _muscleArray[61] = p61;
            _muscleArray[62] = p62;
            _muscleArray[63] = p63;
            _muscleArray[64] = p64;
            _muscleArray[65] = p65;
            _muscleArray[66] = p66;
            _muscleArray[67] = p67;
            _muscleArray[68] = p68;
            _muscleArray[69] = p69;

            _muscleArray[70] = p70;
            _muscleArray[71] = p71;
            _muscleArray[72] = p72;
            _muscleArray[73] = p73;
            _muscleArray[74] = p74;
            _muscleArray[75] = p75;
            _muscleArray[76] = p76;
            _muscleArray[77] = p77;
            _muscleArray[78] = p78;
            _muscleArray[79] = p79;

            _muscleArray[80] = p80;
            _muscleArray[81] = p81;
            _muscleArray[82] = p82;
            _muscleArray[83] = p83;
            _muscleArray[84] = p84;
            _muscleArray[85] = p85;
            _muscleArray[86] = p86;
            _muscleArray[87] = p87;
            _muscleArray[88] = p88;
            _muscleArray[89] = p89;
            _muscleArray[90] = p90;

            _muscleArray[91] = p91;
            _muscleArray[92] = p92;
            _muscleArray[93] = p93;
            _muscleArray[94] = p94;

        }

        /// <summary>
        /// どのマッスル情報を<see cref="WriteToPose"/>で転写すべきかのフラグ一覧をセットします。
        /// </summary>
        /// <param name="flags"></param>
        public void SetUsedFlags(bool[] flags)
        {
            if (flags == null || flags.Length != _usedMuscleFlags.Length)
            {
                return;
            }
            
            for (int i = 0; i < _usedMuscleFlags.Length; i++)
            {
                _usedMuscleFlags[i] = flags[i];
            }
        }
        
        /// <summary>
        /// 現在のマッスル情報を実際のアバターの姿勢に書き込みます。
        /// </summary>
        /// <param name="pose"></param>
        public void WriteToPose(ref HumanPose pose)
        {
            for (int i = 0; i < _muscleArray.Length; i++)
            {
                if (_usedMuscleFlags[i])
                {
                    pose.muscles[i] = _muscleArray[i];
                }
            }
        }
        
        /// <summary>
        /// 現在のマッスル情報を、指定した比率で実際のアバター姿勢に書き込みます。
        /// 0を指定すると何もせず、1を指定するとrateを指定しない場合と同じ動きになります。
        /// </summary>
        /// <param name="pose"></param>
        /// <param name="rate"></param>
        public void WriteToPose(ref HumanPose pose, float rate)
        {
            for (int i = 0; i < _muscleArray.Length; i++)
            {
                if (_usedMuscleFlags[i])
                {
                    pose.muscles[i] = Mathf.Lerp(pose.muscles[i], _muscleArray[i], rate);
                }
            }
        }
    }
}
