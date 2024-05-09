using UnityEngine;

namespace Game.Reusable
{
    [RequireComponent(typeof(Camera))]
    public class CameraScaler : MonoBehaviour
    {
        [SerializeField] private int _referenceCameraSize = 5;

        private float ReferenceRatio => (float)ReferenceWidth / (float)ReferenceHeight;

        private int ReferenceWidth => 1080;
        private int ReferenceHeight => 1920;

        private void Awake()
        {
            var camera = FindCamera();

            var currentRatio = (float)Screen.width / (float)Screen.height;
            var cameraSize = (float)_referenceCameraSize / ReferenceRatio * currentRatio;

            if (cameraSize <= 0f) return;

            camera.orthographicSize = cameraSize;
        }

        private void OnValidate()
        {
            var camera = FindCamera();
            camera.orthographicSize = _referenceCameraSize;
        }

        private Camera FindCamera() => GetComponent<Camera>();
    }
}