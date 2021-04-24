using UnityEngine;

namespace Eray.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpMult;
        [SerializeField] private float turnSmoothMult;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform cam;
        private float _verticalValue;
        private float _horizontalValue;

        private Vector3 _playerDir;
        private float _targetAngle;
        private float _smoothAngleVelocity;
        private bool _isAiming;
        private bool _canJump;


        private void Update()
        {
            _verticalValue = Input.GetAxisRaw("Vertical");
            _horizontalValue = Input.GetAxisRaw("Horizontal");

            _playerDir = new Vector3(_horizontalValue, 0, _verticalValue).normalized;

            if (Input.GetMouseButtonDown(1))
            {
                _isAiming = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                _isAiming = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
                _canJump = true;
        }

        private void FixedUpdate()
        {
            Move();
            if (_canJump)
            {
                _canJump = false;
                Jump();
            }
                
        }

        private void Move()
        {
            if (_playerDir.magnitude >= .1f)
            {
                _targetAngle = Mathf.Atan2(_playerDir.x, _playerDir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

                var smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 
                    _targetAngle, ref _smoothAngleVelocity, turnSmoothMult);
                
                transform.rotation = Quaternion.Euler(0, _targetAngle, 0);

                Vector3 moveDirection = Quaternion.Euler(0, smoothAngle, 0) * Vector3.forward;
                
                
                var moveMult = moveSpeed * Time.fixedDeltaTime;

                //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.fixedDeltaTime * 4);
                //transform.Translate(moveDirection.normalized * moveMult, Space.World);
                //moveDirection = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
                rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z) * moveMult;
            }
        }

        private void Jump()
        {
            rb.AddForce(Vector3.up * jumpMult, ForceMode.Impulse);
        }
        

    }
}