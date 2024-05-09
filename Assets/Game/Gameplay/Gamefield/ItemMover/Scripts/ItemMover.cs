using Game.Gameplay.Field.Items;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Field
{
    public class ItemMover : MonoBehaviour
    {
        [SerializeField] [Range(0.1f, 1f)] private float _moveStep;

        private Input _input;
        private ItemFinder _itemFinder;

        private AbstractItem _takenItem;

        private Vector2 ScreenPosition => _input.ItemMover.Move.ReadValue<Vector2>();

        [Inject]
        private void Initialize(ItemFinder itemFinder)
        {
            _itemFinder = itemFinder;
            _input = new();
        }

        private void TryTakeItem()
        {
            _takenItem = _itemFinder.FindAt(ScreenPosition);
            if (_takenItem == null) return; 
            _takenItem.Select();
        }
        private void TryPutItem()
        {
            if (_takenItem == null) return; 
            _takenItem.Deselect();
            _takenItem = null;
        }

        private void Update()
        {
            if (_takenItem == null) return;

            var startPosition = _takenItem.transform.position;
            var endPosition = Camera.main.ScreenToWorldPoint(ScreenPosition);
            endPosition.z = _takenItem.transform.position.z;

            _takenItem.transform.position = Vector3.Lerp(startPosition, endPosition, _moveStep);
        }

        private void OnEnable()
        {
            _input.Enable();
            _input.ItemMover.Contact.performed += _ => TryTakeItem();
            _input.ItemMover.Contact.canceled += _ => TryPutItem();
        }
        private void OnDisable()
        {
            _input.ItemMover.Contact.performed -= _ => TryTakeItem();
            _input.ItemMover.Contact.canceled -= _ => TryPutItem();
            _input.Disable();
        }
    }
}