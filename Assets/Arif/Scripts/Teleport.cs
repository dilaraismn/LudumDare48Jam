using System;
using Eray.Scripts;
using UnityEngine;

namespace Arif.Scripts
{
    public class Teleport : MonoBehaviour
    {
        public Transform teleportTransform;
        public bool isLab;
        
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerMovement>();
            if (player)
            {
                if (!CameraFollow.instance.topDownView)
                {
                    CameraFollow.instance.SwitchToTopDown();
                }
                else
                {
                    CameraFollow.instance.SwitchToTopDown();
                }
                
                player.transform.position = teleportTransform.position;
            }
        }
    }
}
