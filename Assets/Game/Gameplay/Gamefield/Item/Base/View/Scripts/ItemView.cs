using Game.Reusable;
using System;
using TMPro;
using UnityEngine;

namespace Game.Gameplay.Field.Items
{
    [RequireComponent(typeof(AbstractItem))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(ItemScalingAnimation))]
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private LevelSpriteList _sprites;
        [SerializeField] [Min(0.1f)] private float _selectedScale;
        [SerializeField] private TextMeshPro _nameText;
        [SerializeField] private ParticleSystem _particles;

        private AbstractItem _item;
        private SpriteRenderer _renderer;
        private ItemScalingAnimation _scalingAnimation;

        private Vector3 _defaultScale;

        private void Start()
        {
            _item = GetComponent<AbstractItem>();
            _renderer = GetComponent<SpriteRenderer>();
            _scalingAnimation = GetComponent<ItemScalingAnimation>();

            _defaultScale = transform.localScale;

            UpdateLevel(_item.Parameters);
            StartAppearanceAnimation();

            _item.Updated += UpdateLevel;
            _item.Selected += StartSelectedAnimation;
            _item.Deselected += EndSelectedAnimation;
        }

        private void UpdateLevel(Parameters parameters)
        {
            UpdateSprite(parameters);
            UpdateName(parameters);
            _particles.Play();
        }

        private void UpdateSprite(Parameters parameters)
        {
            _renderer.sprite = _sprites.GetSpriteByLevel(parameters.Level);
        }

        private void UpdateName(Parameters parameters)
        {
            _nameText.text = $"Level: {parameters.Level + 1}";
        }

        private void StartAppearanceAnimation()
        {
            _scalingAnimation.Scale(0f, _defaultScale);
        }

        private void StartSelectedAnimation()
        {
            _renderer.sortingOrder++;
            _scalingAnimation.Scale(transform.localScale, _selectedScale);
        }

        private void EndSelectedAnimation()
        {
            _scalingAnimation.Scale(_selectedScale, _defaultScale, () => _renderer.sortingOrder--);
        }

        private void OnDestroy()
        {
            _item.Updated -= UpdateLevel;
            _item.Selected -= StartSelectedAnimation;
            _item.Deselected -= EndSelectedAnimation;
        }
    }
}