using UnityEngine;

namespace Game.Gameplay.Field
{
    public class ViewInstaller : MonoBehaviour
    {
        [SerializeField] private BackgroundView _background;

        public void Install(Vector2Int size)
        {
            _background.Install(size);
        }
    }
}