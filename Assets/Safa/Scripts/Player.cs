using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Safa.Scripts
{
    public class Player : MonoBehaviour
    {

        HealthSystem healthSystem;
        public Transform targetPoint;


        private void Awake()
        {
            healthSystem = GetComponent<HealthSystem>();


        }


        private void OnEnable()
        {
            healthSystem.onDeath += Player_onDeath;
        }

        private void Player_onDeath()
        {
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            healthSystem.onDeath -= Player_onDeath;

        }






    }

}

