using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> _transforms;
        [SerializeField] private InvaderManager _invaderManager;
        [SerializeField] private Player _player;

        private List<Vector3> _restorePositions;

        private void OnEnable()
        {
            _invaderManager.GameOver += RestartGame;
            _player.GameOver += RestartGame;
        }

        private void OnDisable()
        {
            _invaderManager.GameOver -= RestartGame;
            _player.GameOver -= RestartGame;
        }

        private void Awake()
        {
            _restorePositions = new List<Vector3>();

            foreach (var transformToSave in _transforms)
            {
                _restorePositions.Add(transformToSave.position);
            }
        }

        private void RestartGame()
        {
            for (var i = 0; i < _transforms.Count; i++)
            {
                _transforms[i].position = _restorePositions[i];
            }

            _invaderManager.RestoreAllInvaders();
        }
    }
}