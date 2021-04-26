using System.Collections;
using Cagri.Scripts;
using Safa.Scripts;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

namespace Mehmethan.Scripts
{
    public class ArcherEnemy : MonoBehaviour,IEnemy
    {
        [SerializeField] private float lookRadius = 6f;
        [SerializeField] private float timeBetweenAttacks;
        [SerializeField] private GameObject bow;
        
        private Transform _target;
        private NavMeshAgent _agent;
        private float _timeSinceLastAttack;
        public bool TriggerArcherEnemy;
        private Quaternion lookRotation;
        private Animator animator;
        public Animator bowAnimator;
        public Transform ArrowPossition;
        
        [HideInInspector]public HealthSystem healthSystem;

        private void OnEnable()
        {
            healthSystem.onDeath += Enemy_onDeath;
        }

        private void Enemy_onDeath()
        {
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            healthSystem.onDeath -= Enemy_onDeath;

        }
        private void Awake()
        {
            healthSystem = GetComponent<HealthSystem>();
          
        }
        void Start()
        {
            animator = GetComponent<Animator>();
            _target = LevelManager.manager.player.transform;
            _agent = GetComponent<NavMeshAgent>(); // todo navmesh Layer Ayarla
        }
    

        void Update()
        {
            if (!_isActive)
            {
                return;
            }
            if (!_target)
            {
                return;
            }
            _timeSinceLastAttack += Time.deltaTime;
            
            float distance = Vector3.Distance(_target.position, transform.position);

            if (distance <= lookRadius)
            {
                _agent.stoppingDistance = 5f;
                TriggerArcherEnemy = true;
                _agent.speed = 2.5f;
                animator.SetBool("Run",true);
                _agent.SetDestination(_target.position);
                
            }
            else
            {
                _agent.stoppingDistance = 2.5f;
                _agent.speed = 1f;
                animator.SetBool("Run",false);
                TriggerArcherEnemy = false;
            }

            if (distance <= _agent.stoppingDistance)
            {
                RotateTarget();
                animator.SetBool("Attack",false);
                bowAnimator.SetBool("Attack",false);
                if (_timeSinceLastAttack > timeBetweenAttacks)
                {
                    animator.SetBool("Attack",true);
                    bowAnimator.SetBool("Attack",true);
                    OnAttack();
                    _timeSinceLastAttack = 0;
                }

                if (_timeSinceLastAttack<timeBetweenAttacks)
                {
                   // Reload Animasyon
                }
            }
        }
        private void RotateTarget()
        {
            Vector3 directon = (_target.position - transform.position).normalized;
           lookRotation = Quaternion.LookRotation(new Vector3(directon.x, 0, directon.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
        
        private void OnAttack()
        {
            StartCoroutine(BowForward());
        }

        IEnumerator BowForward()
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(bow, ArrowPossition.position, lookRotation);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
        }

       

        public void OnPlayerHit()
        {
            healthSystem.DealDamage(LevelManager.manager.player.playerDamage);
        }

        private bool _isActive=true;
        public void OnActive()
        {
            _isActive = true;
        }

        public void OnDeActive()
        {
            _isActive = false;
            _agent.SetDestination(transform.position);

        }
    }
}