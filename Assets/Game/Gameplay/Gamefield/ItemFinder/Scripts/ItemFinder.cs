using Game.Gameplay.Field.Items;
using UnityEngine;

namespace Game.Gameplay.Field
{
    public class ItemFinder : MonoBehaviour
    {
        public AbstractItem FindAt(Vector2 screenPosition)
        {
            var ray = Camera.main.ScreenPointToRay(screenPosition);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider == null || hit.transform == null) return null;

            var item = hit.collider.GetComponent<AbstractItem>();
            return item;
        }

        public AbstractItem FindByWorldPosition(Vector2 position)
        {
            var convertedPosition = Camera.main.WorldToScreenPoint(position);
            return FindAt(convertedPosition);
        }
    }
}