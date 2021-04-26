using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

namespace Mehmethan.Scripts
{
    public class PatrolPath : MonoBehaviour
    {
        public enum EnemyType
        {
            Archer,
            Melee
        }

        public EnemyType currentEnemyType;
        [SerializeField] private float distanceFromTarget = 3f;
        public Transform[] waypoints;
        private NavMeshAgent _agent;
        private int waypointIndex;
        private float dist;
        private MeleeEnemyController _meleeEnemyController;
        private ArcherEnemy _archerEnemy;
        private Animator animator;

        private void Start()
        {
            switch (currentEnemyType)
            {
                case EnemyType.Archer:
                    _archerEnemy = GetComponent<ArcherEnemy>();
                    break;
                case EnemyType.Melee:
                    _meleeEnemyController = GetComponent<MeleeEnemyController>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
            waypointIndex = 0;
            transform.LookAt(waypoints[waypointIndex].position);
            animator.SetTrigger("Walk");
        }

        private void Update()
        { 
            dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
            
            if (dist < distanceFromTarget)
            {
                IncreaseIndex();
            }
            Patrol();
        }
        
        void Patrol()
        {
            switch (currentEnemyType)
            {
                case EnemyType.Archer:
                    if (!_archerEnemy.TriggerArcherEnemy)
                    {
                        _agent.SetDestination(waypoints[waypointIndex].position);
                    }
                    break;
                case EnemyType.Melee:
                    if (!_meleeEnemyController.TriggerEnemy)
                    {
                        _agent.SetDestination(waypoints[waypointIndex].position);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void IncreaseIndex()
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
            transform.LookAt(waypoints[waypointIndex].position);
        }
    }
}