using Eray.Scripts;
using UnityEngine;

namespace Mehmethan.Scripts
{
    public class AttackTrigger : MonoBehaviour
    {
        public float attackDamage = 10;
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerMovement>();
            if (player)
            {
                player._healthSystem.DealDamage(attackDamage);
            }
        }
    }
}
