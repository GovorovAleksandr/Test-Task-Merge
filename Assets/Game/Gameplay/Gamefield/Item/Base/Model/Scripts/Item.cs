using UnityEngine;

namespace Game.Gameplay.Field
{
    [RequireComponent(typeof(Collider2D))]
    public class Item : MonoBehaviour, IItem
    {
        private Collider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }
    }
}