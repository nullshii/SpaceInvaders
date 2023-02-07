using UnityEngine;

namespace Code.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Gun _gun;
        [SerializeField] private PlayerMovementLimiter _playerMovementLimiter;

        private void Update()
        {
            ProcessMobileInput();
            ProcessDesktopInput();
        }

        private void ProcessDesktopInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            const float speed = 20f;
            Move(Vector3.right * horizontal * speed * Time.deltaTime);

            if (Input.GetAxis("Fire1") != 0f)
            {
                _gun.Shoot();
            }
        }

        private void ProcessMobileInput()
        {
            if (Input.touchCount <= 0) return;
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Move(Vector3.right * touch.deltaPosition.x * Time.deltaTime);
            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                _gun.Shoot();
            }
        }

        private void Move(Vector3 nextPosition)
        {
            var calculatedPosition = transform.position + nextPosition;

            if (_playerMovementLimiter.CanMove(calculatedPosition))
                transform.position = calculatedPosition;
        }
    }
}