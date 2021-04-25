﻿using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Eray.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpMult;
        //[SerializeField] private float turnSmoothMult;
        [SerializeField] private float turnAngleSmooth;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Animator animator;
        [SerializeField] private Transform cam;
        [SerializeField] private SpearBehaviour sb;
        [SerializeField] private LayerMask groundCheckLayers;
        private float _verticalValue;
        private float _horizontalValue;

        private Vector3 _playerDir;
        private float _targetAngle;
        //private float _smoothAngleVelocity;
        private bool _canJump;
        private float _angle;


        private bool _isRunning;
        private bool _isJumping;
        private bool _onGround;
        private bool _isAttacking;

        public bool IsAttacking => _isAttacking;


        private void Update()
        {
            _verticalValue = Input.GetAxisRaw("Vertical");
            _horizontalValue = Input.GetAxisRaw("Horizontal");


            _onGround = GroundCheck();
            _playerDir = new Vector3(_horizontalValue, 0, _verticalValue).normalized;


            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(!_isAttacking)
                    _canJump = true;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if(sb.SpearThrown == false)
                    _isAttacking = true;
            }
            
            HandleAnimation();
        }

        private void FixedUpdate()
        {
            if (!_isAttacking)
            {
                Move2();
                if (_canJump && _onGround)
                {
                    _canJump = false;
                    Jump();
                }
            }
        }

        // private void Move()
        // {
        //     if (_playerDir.magnitude >= .1f)
        //     {
        //         _targetAngle = Mathf.Atan2(_playerDir.x, _playerDir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //
        //         // var smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 
        //         //     _targetAngle, ref _smoothAngleVelocity, turnSmoothMult);
        //         
        //        // transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        //
        //         Vector3 moveDirection = Quaternion.Euler(0, _targetAngle, 0) * Vector3.forward;
        //
        //
        //         //Vector3 moveDirection = Quaternion.LookRotation()
        //         var moveMult = moveSpeed * Time.fixedDeltaTime;
        //
        //         //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.fixedDeltaTime * 4);
        //         //transform.Translate(moveDirection.normalized * moveMult, Space.World);
        //         //moveDirection = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
        //         //rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z) * moveMult;
        //         // moveDirection.y = rb.velocity.y;
        //         // rb.velocity = moveDirection * moveMult;
        //     }
        // }


        private void Move2()
        {
            if (_playerDir.magnitude > .1f)
            {
                _isRunning = _onGround;
                
                if (_horizontalValue == 0)
                {
                    
                }
                else if (_horizontalValue > 0.1f)
                {
                    _angle += turnAngleSmooth;
                    transform.rotation = Quaternion.AngleAxis(_angle, Vector3.up);
                }
                else if (_horizontalValue < 0.1f)
                {
                    _angle -= turnAngleSmooth;
                    transform.rotation = Quaternion.AngleAxis(_angle, Vector3.up);
                }


                //rb.velocity = new Vector3(_playerDir.x, rb.velocity.y, _playerDir.z) * (moveSpeed * Time.fixedDeltaTime);
                var localVal = rb.velocity;
                
                var oldY = localVal.y;
                
                if(_playerDir.z > 0)
                    localVal = transform.forward.normalized * (Time.fixedDeltaTime * moveSpeed * _playerDir.magnitude);
                else if (_playerDir.z < 0)
                    localVal = transform.forward.normalized * (-1 * (Time.fixedDeltaTime * moveSpeed * _playerDir.magnitude));
                
                localVal.y = oldY;
                
                rb.velocity = localVal;
            }
            else
            {
                _isRunning = false;
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }

        }

        private void HandleAnimation()
        {
            animator.SetBool("isRunning", _isRunning);
            animator.SetBool("isAttacking", _isAttacking);
        }
        

        private void Jump()
        {
            rb.AddForce(Vector3.up * jumpMult, ForceMode.Impulse);
        }

        private bool GroundCheck()
        {
            var pos = transform.position + Vector3.up;

            // return (Physics.SphereCast(pos, 
            //     .2f, Vector3.up, out RaycastHit raycastHit, 
            //     .1f, groundCheckLayers));


            return Physics.Raycast(pos, Vector3.down, 1.1f, groundCheckLayers);
        }

        
        
        //using in animation event
        public void SetAttackingFalse()
        {
            _isAttacking = false;
        }
        
        

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position, .2f);
        }
        
        
    }
}