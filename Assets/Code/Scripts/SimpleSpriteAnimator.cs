using UnityEngine;

namespace Code.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SimpleSpriteAnimator : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private float _frameTime;

        private SpriteRenderer _spriteRenderer;
        private int _currentFrame;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            InvokeRepeating(nameof(Animate), _frameTime, _frameTime);
        }

        private void Animate()
        {
            _currentFrame++;

            if (_currentFrame > _sprites.Length - 1)
                _currentFrame = 0;

            _spriteRenderer.sprite = _sprites[_currentFrame];
        }
    }
}