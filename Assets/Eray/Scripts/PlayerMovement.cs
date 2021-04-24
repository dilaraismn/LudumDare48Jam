using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Eray.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float turnSmoothMult;
        [SerializeField] private Transform cam;
        [SerializeField] private CharacterController characterController;


        private float _verticalValue;
        private float _horizontalValue;

        private Vector3 _playerDir;
        private float _targetAngle;
        private float _smoothAngleVelocity;
        

        private void Update()
        {
            _verticalValue = Input.GetAxisRaw("Vertical");
            _horizontalValue = Input.GetAxisRaw("Horizontal");

            _playerDir = new Vector3(_horizontalValue, 0, _verticalValue).normalized;
        }

        private void FixedUpdate()
        {
            Move();
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
                
                var moveMult = speed * Time.fixedDeltaTime;
                characterController.Move(moveDirection.normalized * moveMult);
            }
        }

    }
}