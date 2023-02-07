using System;
using UnityEngine;

namespace Code.Scripts
{
    public class Player : MonoBehaviour
    {
        public event Action GameOver;

        public void Kill()
        {
            GameOver?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Invader _))
                Kill();
        }
    }
}