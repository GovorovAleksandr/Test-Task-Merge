using System;
using System.Collections;
using UnityEngine;

namespace Game.Reusable
{
    public class PureAnimation
    {
        private readonly MonoBehaviour _context;

        public PureAnimation(MonoBehaviour context) => _context = context;

        public void Play(float duration, Action onAnimationEnd) => Play(duration, _ => { }, onAnimationEnd);
        public void Play(float duration, Action<float> callback) => Play(duration, callback, () => { });

        public void Play(float duration, Action<float> callback, Action onAnimationEnd)
        {
            if (_context.gameObject.activeSelf == false) return;
            _context.StartCoroutine(GetAnimation(duration, callback, onAnimationEnd));
        }

        private IEnumerator GetAnimation(float duration, Action<float> callback, Action animationEnded)
        {
            var expiredSeconds = 0f;
            var progress = 0f;

            while (progress < 1f)
            {
                expiredSeconds += Time.deltaTime;
                progress = expiredSeconds / duration;
                callback?.Invoke(progress);
                yield return null;
            }

            callback?.Invoke(1f);
            animationEnded?.Invoke();
        }
    }
}