#if UNITY_EDITOR
using UnityEngine;

namespace Game.Gameplay.Field
{
    public class EditorView : MonoBehaviour
    {
        [SerializeField] private Setup _setup;
        [SerializeField] private Color _color;

        private void OnDrawGizmos()
        {
            Gizmos.color = _color;
            if (_setup == null) return;

            var pos = transform.position;
            Vector3 size = (Vector2)_setup.Size;

            Gizmos.DrawLine(pos - size / 2f, pos - size / 2f + Vector3.up * size.y);
            Gizmos.DrawLine(pos + size / 2f, pos - size / 2f + Vector3.up * size.y);

            Gizmos.DrawLine(pos - size / 2f, pos - size / 2f + Vector3.right * size.x);
            Gizmos.DrawLine(pos + size / 2f, pos - size / 2f + Vector3.right * size.x);
        }
    }
}
#endif