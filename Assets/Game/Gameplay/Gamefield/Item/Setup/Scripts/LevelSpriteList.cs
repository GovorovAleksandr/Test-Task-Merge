using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Field.Items
{
    [CreateAssetMenu(fileName = "ItemLevelsSetup", menuName = "Gameplay/Field/Items/Setup")]
    public class LevelSpriteList : ScriptableObject
    {
        [SerializeField] private List<Sprite> _elements = new();

        public static int MaxLevel { get; private set; }

        private void OnValidate() => MaxLevel = _elements.Count - 1;

        public Sprite GetSpriteByLevel(int level)
        {
            var index = Mathf.Clamp(level, 0, _elements.Count - 1);
            return _elements[index];
        }
    }
}