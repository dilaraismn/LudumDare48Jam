using System;
using System.Collections;
using Cagri.Scripts;
using Safa.Scripts;
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
        private bool _canAttack;
        private bool hitThePlayer;
        private HealthSystem myHealth;
        private Transform player;
        public float attackDamage = 10;

        public void OnPlayerHit()
        {
            myHealth.DealDamage(LevelManager.manager.player.playerDamage);
        }

        public void OnDeath()
        {
            StartCoroutine(DeathRoutine());
        }

        IEnumerator DeathRoutine()
        {
            agent.enabled = false;
            anim.SetTrigger("isDying");
            yield return new WaitForSeconds(4);
            GameManager.manager.WinGame();
        }


        private void OnEnable()
        {
            myHealth.onDeath += OnDeath;
        }

        private void OnDisable()
        {
            myHealth.onDeath -= OnDeath;
        }

        public void OnActive()
        {
            
        }

        public void OnDeActive()
        {
            
        }

        private void Awake()
        {
            myHealth = GetComponent<HealthSystem>();
        }

        private void Attack()
        {
            if (_playerInRange && !_isScreaming)
            {
                _isAttacking = true;
                hitThePlayer = false;
            }
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
            StartCoroutine(StartFight());
        }

        IEnumerator StartFight()
        {
            Scream();
            yield return new WaitForSeconds(2);
            _canMove = true;
            _isScreaming = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isAttacking && !hitThePlayer)
            {
                if (other.gameObject.GetComponent<PlayerMovement>())
                {
                    hitThePlayer = true;
                    
                    LevelManager.manager.player._healthSystem.DealDamage(attackDamage);
                }
            }
           
        }
    }
}