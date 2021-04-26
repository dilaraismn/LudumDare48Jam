using System;
using Furkan.Powerup;
using UnityEngine;

namespace Furkan.Scripts
{
    public class SpawnRandomPower : MonoBehaviour
    {
        private void Start()
        {
            PowerupController.instance.SpawnPowerup(PowerupController.instance.powerups[UnityEngine.Random.Range(0,PowerupController.instance.powerups.Count)], transform.position);
        }
    }
}
