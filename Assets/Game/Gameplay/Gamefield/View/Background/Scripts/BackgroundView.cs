using UnityEngine;

namespace Game.Gameplay.Field
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BackgroundView : MonoBehaviour
    {
        public void Install(Vector2Int size)
        {
            transform.localScale = (Vector2)size;
        }
    }
}