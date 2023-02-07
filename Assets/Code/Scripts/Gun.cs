using UnityEngine;

namespace Code.Scripts
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Projectile _projectile;
        private Projectile _instantiatedProjectile;

        public void Shoot()
        {
            if (_instantiatedProjectile != null) return;

            _instantiatedProjectile = Instantiate(_projectile, transform.position, Quaternion.identity);
        }
    }
}