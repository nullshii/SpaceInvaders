using Zenject;
using UnityEngine;

namespace Code.Scripts
{
    public class Invader : MonoBehaviour
    {
        [SerializeField] private Gun _gun;

        [Inject] private InvaderManager _invaderManager;

        public bool IsAlive => gameObject.activeInHierarchy;

        private void Awake()
        {
            _invaderManager.Add(this);
        }

        public void Shoot()
        {
            _gun.Shoot();
        }

        public void Kill()
        {
            _invaderManager.Kill(this);
        }
    }
}