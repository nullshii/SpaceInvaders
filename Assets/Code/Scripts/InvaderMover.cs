using UnityEngine;
using Zenject;

namespace Code.Scripts
{
    public class InvaderMover : MonoBehaviour
    {
        [SerializeField] private Camera _referenceCamera;
        [SerializeField] private float _padding;
        [SerializeField] private AnimationCurve _speed;
        [SerializeField] private float _downOffset;

        [Inject] private InvaderManager _invaderManager;

        private Vector3 _direction = Vector3.right;
        private Vector3 _leftEdge;
        private Vector3 _rightEdge;

        private void Start()
        {
            _leftEdge = _referenceCamera.ViewportToWorldPoint(Vector3.zero);
            _rightEdge = _referenceCamera.ViewportToWorldPoint(Vector3.right);
        }

        private void Update()
        {
            var deadPercentage = _invaderManager.DeadPercentage;

            if (deadPercentage == 1f) return;

            transform.position += _direction * (_speed.Evaluate(deadPercentage) * Time.deltaTime);

            foreach (Transform invader in transform)
            {
                if (invader.gameObject.activeInHierarchy == false) continue;

                if (_direction == Vector3.right && invader.position.x >= _rightEdge.x - _padding
                    || _direction == Vector3.left && invader.position.x <= _leftEdge.x + _padding)
                {
                    _direction *= -1f;
                    transform.position += _downOffset * Vector3.down;
                }
            }
        }
    }
}