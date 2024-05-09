using Game.Gameplay.Field.Items;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Field.Factory
{
    public class ItemFactory : MonoBehaviour
    {
        [SerializeField] private Item _prefab;
        [SerializeField] private LevelSpriteList _levelList;
        [SerializeField] private Setup _setup;

        [Inject] private readonly DiContainer _container;

        private Vector3 _minPos;
        private Vector3 _maxPos;

        public void Initialize(Vector3 min, Vector3 max)
        {
            _minPos = min + _prefab.transform.localScale * 0.5f;
            _maxPos = max - _prefab.transform.localScale * 0.5f;
        }

        private void Awake() => StartCoroutine(StartSpawnLoop());

        private IEnumerator StartSpawnLoop()
        {
            while (true)
            {
                SpawnItem();

                yield return new WaitUntil(() => transform.childCount < _setup.MaxItemsCount);
                yield return new WaitForSecondsRealtime(_setup.WaitDuration);
            }
        }

        public void SpawnItem()
        {
            var x = Random.Range(_minPos.x, _maxPos.x);
            var y = Random.Range(_minPos.y, _maxPos.y);
            Vector2 position = new(x, y);

            _container.InstantiatePrefabForComponent<AbstractItem>(_prefab, position, Quaternion.identity, transform);
        }
    }
}