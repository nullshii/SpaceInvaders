using UnityEngine;

namespace Code.Scripts
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Vector3 _direction;
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.position += _direction * _speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IKillable killable))
            {
                killable.Kill();
            }

            Destroy(gameObject);
        }
    }
}