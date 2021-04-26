using System;
using Cagri.Scripts;
using UnityEngine;

namespace Eray.Scripts
{
    public class Boss : MonoBehaviour, IEnemy
    {
        [SerializeField] private Animator anim;
        [SerializeField] private float turnSpeed;
        [SerializeField] private float moveSpeed;
        [SerializeField] 

        private bool _isAttacking;
        private bool _isScreaming;
        private bool _playerInRange;
        private bool _isMoving;
        private bool _canMove;
        private bool _canRotate;
        private bool _canAttack;

        private Transform player;

        public void OnPlayerHit()
        {
            throw new NotImplementedException();
        }

        public void OnActive()
        {
            throw new NotImplementedException();
        }

        public void OnDeActive()
        {
            throw new NotImplementedException();
        }

        private void Awake()
        {
            _canRotate = true;
            _canMove = true;
        }

        private void Attack()
        {
            if (_playerInRange && !_isScreaming)
                _isAttacking = true;
            if (_isAttacking)
            {
                _isAttacking = false;
                _canMove = false;
                _canRotate = false;
                _canAttack = false;
            }
        }

        private void Update()
        {
            BossLogic();
        }

        private void RotateToPlayer()
        {
            if (_canRotate && !_isAttacking)
            {
                var dir = (player.position - transform.position).normalized;
                var lookRot = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * turnSpeed);
            }
        }

        private void MoveToPlayer()
        {
            if (_canMove && !_playerInRange)
            {
                _isMoving = true;
                RotateToPlayer();
                transform.position += transform.forward.normalized * (Time.deltaTime * moveSpeed);
                //Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * moveSpeed);
            }
        }

        private void Scream()
        {
            _isScreaming = true;
            _canMove = false;
            _canRotate = false;
        }

        private void BossLogic()
        {
            if(!player) return;
            
            MoveToPlayer();
            
            HandleAnimation();
        }

        private void HandleAnimation()
        {
            anim.SetBool("isMoving", _isMoving);
            anim.SetBool("isAttacking", _isAttacking);
            anim.SetBool("isScreaming", _isScreaming);
        }

        //using in animation event
        public void EndOfAttack()
        {
            //_state = _attackState;
            _canMove = true;
            _canRotate = true;
        }

        public void SetPlayer(Transform t)
        {
            player = t;
        }

       
        
        
    }
}