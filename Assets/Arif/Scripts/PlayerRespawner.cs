using System;
using Eray.Scripts;
using UnityEngine;

namespace Arif.Scripts
{
    public class PlayerRespawner : MonoBehaviour
    {
        public Transform spawnPoint;
        public float spawnDamage = 10f;


        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerMovement>();
            if (player)
            {
                player.transform.position = spawnPoint.position;
                player._healthSystem.DealDamage(spawnDamage);
            }
        }
    }
}
