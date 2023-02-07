using UnityEngine;

namespace Code.Scripts
{
    public class InvaderSpawner : MonoBehaviour
    {
        [SerializeField] private Invader[] _invaders;
        [SerializeField] private int _columnSize;
        [SerializeField] private Vector2 _offset;

        public void Spawn()
        {
            Vector3 lastPosition = new Vector3(_invaders.Length * _offset.x, _columnSize + _offset.y, 0f);
            var centerOffset = lastPosition * 0.5f;

            for (var i = 0; i < _columnSize; i++)
            {
                for (var j = 0; j < _invaders.Length; j++)
                {
                    var invader = Instantiate(_invaders[j], transform);
                    invader.transform.localPosition = new Vector3(i * _offset.x, j * _offset.y, 0f) - centerOffset;
                }
            }
        }

        public void Destroy()
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
    }
}