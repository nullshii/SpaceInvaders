using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Scripts
{
    public class InvaderManager : MonoBehaviour
    {
        public event Action Win;

        [SerializeField] private float _shootRate;

        private List<Invader> _invaders;

        public float DeadPercentage => (float) _invaders.Count(invader => invader.IsAlive == false) / _invaders.Count;

        private void Awake()
        {
            _invaders = new List<Invader>();
        }

        private void Start()
        {
            InvokeRepeating(nameof(Shoot), _shootRate, _shootRate);
        }

        private void Shoot()
        {
            if (Random.value < DeadPercentage)
            {
                Debug.Log("Shoot");

                var random = new System.Random();
                var randomInvader = _invaders.Where(i => i.IsAlive).OrderBy(_ => random.Next()).First();

                randomInvader.Shoot();
            }
        }

        public void Add(Invader invader)
        {
            if (invader != null)
                _invaders.Add(invader);
        }

        public void Kill(Invader invader)
        {
            var invaderIndex = _invaders.FindIndex(i => i == invader);

            if (invaderIndex == -1)
                throw new IndexOutOfRangeException("Can't find invader!");

            var foundInvader = _invaders[invaderIndex];

            if (foundInvader.IsAlive == false)
                throw new InvalidOperationException("Invader already died!");

            foundInvader.gameObject.SetActive(false);

            if (DeadPercentage == 1f)
                Win?.Invoke();
        }

        public void RestoreAllInvaders()
        {
            foreach (var invader in _invaders)
            {
                invader.gameObject.SetActive(true);
            }
        }
    }
}