using Zenject;
using UnityEngine;

namespace Code.Scripts
{
    public class Invader : MonoBehaviour, IKillable
    {
        [SerializeField] private Gun _gun;

        [Inject] private InvaderManager _invaderManager;

        public bool IsAlive => gameObject.activeInHierarchy;

        private void Start()
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