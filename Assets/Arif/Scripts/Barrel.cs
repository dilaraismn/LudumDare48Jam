using System;
using Cagri.Scripts;
using Mehmethan.Scripts;
using Safa.Scripts;
using Sevval;
using UnityEngine;

namespace Arif.Scripts
{
    public class Barrel : MonoBehaviour,IEnemy
    {
        public HealthSystem myHealth;
        private bool _isActive;
        public BreakParticle myBreak;

        private void OnEnable()
        {
            myHealth.onDeath += OnDeath;
        }

        private void OnDisable()
        {
            myHealth.onDeath -= OnDeath;
        }

        public void OnPlayerHit()
       {
           if (!_isActive)
           {
               return;
           }
           
           myHealth.DealDamage(LevelManager.manager.player.playerDamage);
       }

       public void OnDeath()
       {
           GetComponent<LootSystem>().Spawner();
           myBreak.OnDeath();
           Destroy(gameObject);
       }
       
       public void OnActive()
       {
           _isActive = true;
       }

       public void OnDeActive()
       {
           _isActive = false;
       }
    }
}
