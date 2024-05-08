using System.Collections;
using UnityEngine;

namespace Game.Gameplay.Field
{
    public class ItemFactory : MonoBehaviour
    {
        [SerializeField] private Item _prefab;
        [SerializeField] [Min(1f)] private float _waitDuration;
        [SerializeField] [Min(1)] private int _maxItemsCount;

        private Vector2 _minPos;
        private Vector2 _maxPos;

        public void Install(Vector3 borderSize)
        {
            _minPos = transform.position - borderSize / 2f + _prefab.transform.localScale / 2f;
            _maxPos = transform.position + borderSize / 2f - _prefab.transform.localScale / 2f;

            StartCoroutine(StartSpawnLoop());
        }
        
        private IEnumerator StartSpawnLoop()
        {
            for(int i = 0; i <  _maxItemsCount; i++)
            {
                var x = Random.Range(_minPos.x, _maxPos.x);
                var y = Random.Range(_minPos.y, _maxPos.y);

                Vector2 position = new(x, y);
                Instantiate(_prefab, position, Quaternion.identity, transform);
                yield return new WaitForSecondsRealtime(_waitDuration);
            }
        }
    }
}