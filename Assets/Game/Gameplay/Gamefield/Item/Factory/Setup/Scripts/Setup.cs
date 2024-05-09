using UnityEngine;

namespace Game.Gameplay.Field.Factory
{
    [CreateAssetMenu(fileName = "FactorySetup", menuName = "Gameplay/Field/Factory/Setup")]
    public class Setup : ScriptableObject
    {
        public float WaitDuration => _waitDuration;
        [SerializeField] [Min(1f)] private float _waitDuration;

        public int MaxItemsCount => _maxItemsCount;
        [SerializeField] [Min(1)] private int _maxItemsCount;
    }
}