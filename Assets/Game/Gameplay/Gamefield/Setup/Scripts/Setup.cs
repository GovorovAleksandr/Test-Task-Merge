using UnityEngine;

namespace Game.Gameplay.Field
{
    [CreateAssetMenu(fileName = "FieldSetup", menuName = "Gameplay/Field/Setup")]
    public class Setup : ScriptableObject
    {
        public Vector2 Min => Vector2.zero - ((Vector2)Size) * 0.5f;
        public Vector2 Max=> Vector2.zero + ((Vector2)Size) * 0.5f;
        public Vector2Int Size => new(_width, _height);

        [SerializeField] [Min(1)] private int _width;
        [SerializeField] [Min(1)] private int _height;
    }
}