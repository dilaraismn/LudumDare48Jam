using System;
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
        private Vector3 worldPlayerDir;
        private float angle;
        private float angleSmooth = 2;


        private void Update()
        {
            _verticalValue = Input.GetAxisRaw("Vertical");
            _horizontalValue = Input.GetAxisRaw("Horizontal");

            _playerDir = new Vector3(_horizontalValue, 0, _verticalValue).normalized;

            worldPlayerDir =  transform.InverseTransformDirection(_playerDir);

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
            Move2();
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
                
                transform.rotation = Quaternion.Euler(0, smoothAngle, 0);

                Vector3 moveDirection = Quaternion.Euler(0, _targetAngle, 0) * Vector3.forward;


                //Vector3 moveDirection = Quaternion.LookRotation()
                var moveMult = moveSpeed * Time.fixedDeltaTime;

                //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.fixedDeltaTime * 4);
                //transform.Translate(moveDirection.normalized * moveMult, Space.World);
                //moveDirection = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
                //rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z) * moveMult;
                // moveDirection.y = rb.velocity.y;
                // rb.velocity = moveDirection * moveMult;
            }
        }


        private void Move2()
        {
            if (_playerDir.magnitude > .1f)
            {
                if (_horizontalValue == 0)
                {
                    
                }
                else if (_horizontalValue > 0.1f)
                {
                    angle += angleSmooth;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                }
                else if (_horizontalValue < 0.1f)
                {
                    angle -= angleSmooth;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                }
                

                var localVal = rb.velocity;

                var oldY = localVal.y;

                localVal = transform.forward.normalized * (Time.fixedDeltaTime * moveSpeed * _playerDir.magnitude);

                localVal.y = oldY;

                rb.velocity = localVal;
            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }

        }

        private void Jump()
        {
            rb.AddForce(Vector3.up * jumpMult, ForceMode.Impulse);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position, .2f);
        }
    }
}