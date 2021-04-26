using System;
using System.Collections;
using Cagri.Scripts;
using UnityEngine;
using UnityEngine.AI;

namespace Eray.Scripts
{
    public class Boss : MonoBehaviour, IEnemy
    {
        [SerializeField] private Animator anim;
        [SerializeField] private NavMeshAgent agent;

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
            _canMove = true;
        }

        private void Attack()
        {
            if (_playerInRange && !_isScreaming)
                _isAttacking = true;
            if (_isAttacking)
            {
                _canMove = false;
                _canAttack = false;
            }
        }

        private void Update()
        {
            BossLogic();
        }

        // private void RotateToPlayer()
        // {
        //     if (_canRotate && !_isAttacking)
        //     {
        //         var dir = (player.position - transform.position).normalized;
        //         var lookRot = Quaternion.LookRotation(dir);
        //         transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * turnSpeed);
        //     }
        // }

        private void MoveToPlayer()
        {
            if (_canMove && !_playerInRange)
            {
                _isMoving = true;
                agent.SetDestination(player.position);
                var dir = (player.position - transform.position).normalized;
                var angle = Vector3.Angle(dir, transform.forward);
                var val = (player.position - transform.position).magnitude;

                if (angle > 30)
                {
                    var lookRot = Quaternion.LookRotation(dir);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5);
                }
                
                if (val <= agent.stoppingDistance && angle <= 30f)
                {
                    _canMove = false;
                    _isMoving = false;
                    _playerInRange = true;
                }
                else
                {
                    _playerInRange = false;
                }
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
            
            Attack();
                
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
            _canMove = true;
            _canAttack = true;
            _isAttacking = false;
            _playerInRange = false;
        }

        public void SetPlayer(Transform t)
        {
            player = t;
        }

        IEnumerator StartFight()
        {
            Scream();
            yield return new WaitForSeconds(4);
            agent.SetDestination(player.position);
        }

       
        
        
    }
}