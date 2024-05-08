using Zenject;
using UnityEngine;

namespace Game.Gameplay
{
    public class Entry : MonoInstaller
    {
        [SerializeField] private Field.Setup _fieldSetup;

        public override void InstallBindings()
        {
            Container.Bind<Field.Setup>().
                FromInstance(_fieldSetup).
                AsSingle().
                NonLazy();
        }
    }
}