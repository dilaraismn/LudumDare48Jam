using System;
using Eray.Scripts;
using UnityEngine;

namespace Arif.Scripts
{
    public class SwitchTps : MonoBehaviour
    {
        public bool toTps;

        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerMovement>();
            if (player)
            {
                if (toTps)
                {
                    CameraFollow.instance.SwitchToTopDown();
                }
                else
                {
                    CameraFollow.instance.BackToThirdPerson();
                }
                
                Destroy(gameObject);
            }
        }
    }
}
