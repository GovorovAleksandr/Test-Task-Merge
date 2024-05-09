#if UNITY_EDITOR
using UnityEngine;

namespace Game.Gameplay.Field
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(BackgroundView))]
    public class EditorBackgroundView : MonoBehaviour
    {
        [SerializeField] private Setup _setup;

        private void Update() => transform.localScale = (Vector2)_setup.Size;
    }
}
#endif