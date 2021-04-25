using UnityEngine;
using UnityEngine.AI;

namespace Mehmethan.Scripts
{
    public class MeleeEnemyController : MonoBehaviour
    {
        
        [SerializeField] private float  lookRadius = 4f;
        [SerializeField] private float timeBetweenAttacks;
        private Transform _target;
        private NavMeshAgent _agent;
        private float _timeSinceLastAttack;
        public bool TriggerEnemy;
        void Start()
        {
            _target = PlayerManager.instance.player.transform;
            _agent = GetComponent<NavMeshAgent>();
        }

        
        void Update()
        {
            _timeSinceLastAttack += Time.deltaTime;
            float distance = Vector3.Distance(_target.position, transform.position);
            
            if (distance <= lookRadius)
            {
                TriggerEnemy = true;
                _agent.SetDestination(_target.position);
            }
            else
            {
                TriggerEnemy = false;
            }
            
            if (distance <= _agent.stoppingDistance)
            {
                RotateTarget();
                if (_timeSinceLastAttack>timeBetweenAttacks)
                {
                    OnAttack();
                    _timeSinceLastAttack = 0;
                }
            }
            
        }

        private void OnAttack()
        {
            Debug.Log("Saldırı yaptım");
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
    }
} 

