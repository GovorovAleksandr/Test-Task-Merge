using UnityEngine;
using Zenject;

namespace Game.Gameplay.Field
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private ViewInstaller _viewInstaller;
        [SerializeField] private ItemFactory _itemFactory;

        [Inject]
        private void Install(Setup setup)
        {
            _itemFactory.Install((Vector2)setup.Size);

            _viewInstaller.Install(setup.Size);
        }
    }
}