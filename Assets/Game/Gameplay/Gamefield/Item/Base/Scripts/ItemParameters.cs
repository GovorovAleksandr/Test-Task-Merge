using System;

namespace Game.Gameplay.Field.Items
{
    [Serializable]
    public readonly struct Parameters
    {
        public readonly int Level;

        private Parameters(int level) => Level = level;

        public static Parameters GetDefault() => new (0);
        public Parameters LevelUp()
        {
            if (Level == LevelSpriteList.MaxLevel) return this;
            return new(Level + 1);
        }
    }
}