using UnityEngine;
using Zenject;

namespace Game.Gameplay.Field
{
    public class Installer : MonoInstaller
    {
        [SerializeField] private ViewInstaller _viewInstaller;
        [SerializeField] private Factory.ItemFactory _itemFactory;
        [SerializeField] private ItemFinder _itemFinder;

        [Inject]
        private void Install(Setup setup)
        {
            Vector2 offset = transform.position;
            _itemFactory.Initialize(setup.Min + offset, setup.Max + offset);

            _viewInstaller.Install(setup.Size);
        }

        public override void InstallBindings()
        {
            Container.Bind<ItemFinder>().
                FromInstance(_itemFinder).
                AsSingle().
                NonLazy();
        }
    }
}