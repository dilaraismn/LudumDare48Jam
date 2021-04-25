using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Furkan.Powerup
{
    public class PowerupBehaviour : MonoBehaviour
    {
        public PowerupController controller;

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
            if (other.gameObject.tag == "Player")
            {
                ActivatePoweUp();
                gameObject.SetActive(false);
            }
        }

        private void ActivatePoweUp()
        {
            controller.ActivatePowerup(powerup);
        }

        public void SetPowerUp(Powerup powerup)
        {
            this.powerup = powerup;
            gameObject.name = powerup.name;
        }
    }
}