using System.IO;
using UnityEngine;

namespace Baku.VMagicMirror.MotionExporter
{
    public class MotionTestPlay : MonoBehaviour
    {
        [SerializeField] private string fileName;
        [SerializeField] private HumanoidAnimationSetter source;
        [SerializeField] private Animator target;

        private HumanPoseHandler _humanPoseHandler = null;
        private HumanPose _humanPose;

        private Transform _hips;
        private Vector3 _originHipPos;
        private Quaternion _originHipRot;

        private void Start()
        {
            
            _humanPoseHandler = new HumanPoseHandler(target.avatar, target.transform);
            _hips = target.GetBoneTransform(HumanBodyBones.Hips);
            _originHipPos = _hips.localPosition;
            _originHipRot = _hips.localRotation;

            var fileNameWithExt = fileName.EndsWith(".vmm_motion") ? fileName : fileName + ".vmm_motion";
            var filePath = Path.Combine(Application.streamingAssetsPath, fileNameWithExt);
            var json = File.ReadAllText(filePath);
            
            var importer = new MotionImporter();
            var serializedMotion = importer.LoadSerializedMotion(json);
            var clip = importer.Deserialize(serializedMotion);

            var simpleAnimation = source.GetComponent<SimpleAnimation>();
            if (simpleAnimation == null)
            {
                simpleAnimation = source.gameObject.AddComponent<SimpleAnimation>();
            }
            
            source.SetUsedFlags(serializedMotion.LoadMuscleFlags());
            simpleAnimation.AddState(clip, "test");
            simpleAnimation.Play("test");
        }

        private void Update()
        {
            _humanPoseHandler.GetHumanPose(ref _humanPose);
            source.WriteToArray();
            source.WriteToPose(ref _humanPose);
            _humanPoseHandler.SetHumanPose(ref _humanPose);

            _hips.localPosition = _originHipPos;
            //_hips.localRotation = _originHipRot;
        }
    }
}
