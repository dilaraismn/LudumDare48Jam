using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Safa.Scripts
{

    public class HealthSystem : MonoBehaviour
    {

        public float currentHealth;
        public int healthMax = 100;


        public delegate void Death();

        public event Death onDeath;



        private void Awake()
        {
            currentHealth = healthMax;

        }

        public void DealDamage(float damage)
        {
            currentHealth -= damage;


            if (IsDead())
            {
                onDeath?.Invoke();

            }



        }


        public bool IsDead()
        {
            return currentHealth <= 0;

        }

        public bool IsFullHealth()
        {
            return currentHealth == healthMax;
        }


        public void Heal(float healAmount)
        {

            currentHealth += currentHealth;

            if (currentHealth > healthMax)
            {
                currentHealth = healthMax;

            }
        }

    }

}


