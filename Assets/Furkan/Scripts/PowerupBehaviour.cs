using System;
using System.Collections;
using System.Collections.Generic;
using Eray.Scripts;
using UnityEngine;

namespace Furkan.Powerup
{
    public class PowerupBehaviour : MonoBehaviour
    {
        

        [SerializeField]
        Powerup powerup;

        Renderer _renderer;

        Transform initTransform;

        public Material PowerupMaterial
        {
            get { return _renderer.material; }
            set { _renderer.material = value; }
        }

        int rotationPerSecond = 180;

        private void Awake()
        {
            initTransform = transform;
        }

       

        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerMovement>();
            if (player)
            {
                ActivatePoweUp();
                gameObject.SetActive(false);
            }
        }

        private void ActivatePoweUp()
        {
            PowerupController.instance.ActivatePowerup(powerup);
        }

        public void SetPowerUp(Powerup powerup)
        {
            this.powerup = powerup;
            gameObject.name = powerup.name;
        }
    }
}