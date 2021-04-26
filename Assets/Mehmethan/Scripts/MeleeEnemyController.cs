using Cagri.Scripts;
using Safa.Scripts;
using UnityEngine;
using UnityEngine.AI;

namespace Mehmethan.Scripts
{
    public class MeleeEnemyController : MonoBehaviour,IEnemy
    {
        
        [SerializeField] private float  lookRadius = 4f;
        [SerializeField] private float timeBetweenAttacks;
        private Transform _target;
        private NavMeshAgent _agent;
        private float _timeSinceLastAttack;
        public bool TriggerEnemy;
        private Animator animator;
        [HideInInspector]public HealthSystem healthSystem;
        public GameObject AttackCollider;
        private void OnEnable()
        {
            healthSystem.onDeath += Enemy_onDeath;
        }

        private void Enemy_onDeath()
        {
            Destroy(gameObject);
            //todo
        }

        private void OnDisable()
        {
            healthSystem.onDeath -= Enemy_onDeath;

        }
        void Start()
        {
            animator = GetComponent<Animator>();
            _target = LevelManager.manager.player.transform;
            _agent = GetComponent<NavMeshAgent>();
        }

        
        void Update()
        {
            _timeSinceLastAttack += Time.deltaTime;
            float distance = Vector3.Distance(_target.position, transform.position);
            
            if (distance <= lookRadius)
            {
                TriggerEnemy = true;
                _agent.speed = 2.5f;
                animator.SetBool("Run",true);
                _agent.SetDestination(_target.position);
            }
            else
            {
                TriggerEnemy = false;
                _agent.speed = 1f;
                animator.SetBool("Run",false);
            }
            
            if (distance <= _agent.stoppingDistance)
            {
                RotateTarget();
                animator.SetBool("Attack",false);
                if (_timeSinceLastAttack>timeBetweenAttacks)
                {
                    animator.SetBool("Attack",true);
                    OnAttack();
                    _timeSinceLastAttack = 0;
                }
            }
            
        }

        private void OnAttack()
        {
            Debug.Log("Saldırı yaptım");
            //todo kilica ekleme yapilcak
        }
        
        private void RotateTarget()
        {
            Vector3 directon = (_target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directon.x, 0, directon.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
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

        public void OpenAttackCollider()
        {
            AttackCollider.SetActive(true);
        }

        public void CloseAttackCollider()
        {
            AttackCollider.SetActive(false);
        }
    }
} 

