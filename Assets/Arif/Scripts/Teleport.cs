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
                if (isLab)
                {
                    CameraFollow.instance.SwitchToTopDown();
                }
                else
                {
                    CameraFollow.instance.BackToThirdPerson();
                }
                
                
                player.transform.position = teleportTransform.position;
            }
        }
    }
}
