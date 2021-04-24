using System;
using UnityEngine;

namespace Cagri.Scripts
{
    public class HealthManager : MonoBehaviour
    {
        private HealthSystem healthSystem = new HealthSystem(100);
        private void Start()
        {
            Debug.Log("Health: "+healthSystem.GetHealthPercent());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                healthSystem.TakeDamage(10);
                Debug.Log("Health: "+healthSystem.GetHealth());
            }else if (Input.GetKeyDown(KeyCode.S))
            {
                healthSystem.Heal(10);
                Debug.Log("Health: "+healthSystem.GetHealth());
            }
        }
    }
}
