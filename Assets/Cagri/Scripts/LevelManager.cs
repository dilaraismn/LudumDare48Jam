using System;
using System.Collections.Generic;
using Burak.Scripts;
using Eray.Scripts;
using UnityEngine;

namespace Cagri.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager manager;
        public PlayerMovement player;
        
        private void Awake()
        {
            manager = this;
        }

        private void Start()
        {
            UIManager.instance.SetHealthBar(player._healthSystem.healthMax);
            UIManager.instance.SetHealthText(player._healthSystem.healthMax);
        }

        private void Update()
        {
            UIManager.instance.SetHealthBar(player._healthSystem.currentHealth);
            UIManager.instance.SetHealthText(player._healthSystem.currentHealth);
        }
    }
}
