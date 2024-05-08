using UnityEngine;

namespace Game.Gameplay.Field
{
    [CreateAssetMenu(fileName = "Setup", menuName = "Gameplay/Field/Setup")]
    public class Setup : ScriptableObject
    {
        public Vector2Int Size => new(_width, _height);

        [SerializeField] private int _width;
        [SerializeField] private int _height;
    }
}