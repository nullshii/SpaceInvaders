using System;
using UnityEngine;

namespace Code.Scripts
{
    public class Player : MonoBehaviour, IKillable
    {
        public event Action Lose;

        public void Kill()
        {
            Lose?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Invader _))
                Kill();
        }
    }
}