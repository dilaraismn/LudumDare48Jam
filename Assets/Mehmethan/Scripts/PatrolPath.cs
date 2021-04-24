using UnityEngine;
using UnityEngine.AI;

namespace Mehmethan.Scripts
{
    public class PatrolPath : MonoBehaviour
    {
        [SerializeField] private float distanceFromTarget = 3f;
        
        public Transform[] waypoints;
        public int speed;
        private NavMeshAgent _agent;
        private int waypointIndex;
        private float dist;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            waypointIndex = 0;
            transform.LookAt(waypoints[waypointIndex].position);
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
            _agent.SetDestination(waypoints[waypointIndex].position);
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