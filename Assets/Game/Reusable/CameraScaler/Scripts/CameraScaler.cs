using UnityEngine;

namespace Game.Reusable
{
    [RequireComponent(typeof(Camera))]
    public class CameraScaler : MonoBehaviour
    {
        [SerializeField] private int _referenceCameraSize = 5;

        private Camera _camera;

        private float ReferenceRatio => (float)ReferenceWidth / (float)ReferenceHeight;

        private int ReferenceWidth => 1080;
        private int ReferenceHeight => 1920;

        private void Awake()
        {
            FindCamera();

            var currentRatio = (float)Screen.width / (float)Screen.height;

            var newRatio = (float)_referenceCameraSize / ReferenceRatio * currentRatio;

            if (newRatio <= 0f) return;

            _camera.orthographicSize = newRatio;
            ASKfjk();
        }

        private void ASKfjk()
        {
            Debug.Log("asd");
        }

        private void OnValidate()
        {
            FindCamera();
            _camera.orthographicSize = _referenceCameraSize;
        }

        private void FindCamera() => _camera = GetComponent<Camera>();
    }
}