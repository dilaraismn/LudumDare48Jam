using System;
using Eray.Scripts;
using UnityEngine;

namespace Arif.Scripts
{
    public class Teleport : MonoBehaviour
    {
        public Transform teleportTransform;
        
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerMovement>();
            if (player)
            {
                player.transform.position = teleportTransform.position;
            }
        }
    }
}