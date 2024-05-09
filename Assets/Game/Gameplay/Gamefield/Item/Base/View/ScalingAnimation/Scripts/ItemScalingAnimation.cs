using Game.Reusable;
using System;
using UnityEngine;

namespace Game.Gameplay.Field.Items
{
    public class ItemScalingAnimation : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _easing;
        [SerializeField] private float _duration;

        private PureAnimation _animation;

        private void Awake() => _animation = new(this);

        public void Scale(float from, Vector3 to) => Scale(Vector3.one * from, to, () => { });
        public void Scale(Vector3 from, float to) => Scale(from, Vector3.one * to, () => { });
        public void Scale(float from, float to) => Scale(Vector3.one * from, Vector3.one * to, () => { });

        public void Scale(float from, Vector3 to, Action callback) => Scale(Vector3.one * from, to, callback);
        public void Scale(Vector3 from, float to, Action callback) => Scale(from, Vector3.one * to, callback);
        public void Scale(float from, float to, Action callback) => Scale(Vector3.one * from, Vector3.one * to, callback);

        public void Scale(Vector3 from, Vector3 to, Action callback)
        {
            var difference = to - from;

            _animation.Play(_duration, (progress) =>
            {
                transform.localScale = from + (Vector3)(difference * _easing.Evaluate(progress));
            }, callback);
        }
    }
}