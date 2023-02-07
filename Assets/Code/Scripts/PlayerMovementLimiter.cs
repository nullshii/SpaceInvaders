using UnityEngine;

namespace Code.Scripts
{
    public class PlayerMovementLimiter : MonoBehaviour
    {
        [SerializeField] private float _range;
        private Vector3 _initialPosition;

        private void Awake()
        {
            _initialPosition = transform.position;
        }

        public bool CanMove(Vector3 position)
        {
            return position.x < _initialPosition.x + _range && position.x > _initialPosition.x - _range;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawLine(transform.position - Vector3.right * _range, transform.position + Vector3.right * _range);
        }
    }
}