using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Field.Items
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class AbstractItem : MonoBehaviour
    {
        public event Action<Parameters> Updated;
        public event Action Selected;
        public event Action Deselected;

        public Parameters Parameters { get; protected set; }

        private Collider2D _collider;

        [Inject] private readonly ItemFinder _itemFinder;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            Parameters = Parameters.GetDefault();
        }

        public void LevelUp()
        {
            Parameters = Parameters.LevelUp();
            Updated?.Invoke(Parameters);
        }

        public void Select()
        {
            _collider.enabled = false;
            Selected?.Invoke();
        }

        public void Deselect()
        {
            TryDestroyOther();
            _collider.enabled = true;
            Deselected?.Invoke();
        }

        private void TryDestroyOther()
        {
            var other = _itemFinder.FindByWorldPosition(transform.position);

            if (other == null) return;

            if (other.Parameters.Level != Parameters.Level) return;

            Destroy(other.gameObject);
            LevelUp();
        }
    }
}