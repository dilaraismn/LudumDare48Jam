using System;
using System.Collections;
using System.Collections.Generic;
using Cagri.Scripts;
using Eray.Scripts;
using UnityEngine;

namespace Furkan.Powerup
{
    public class PowerupActions : MonoBehaviour
    {
        PlayerMovement player;


        private void Start()
        {
            player = LevelManager.manager.player;
        }

        float multiplier = 1.3f;

        public void HealInstant(float value)
        {
            LevelManager.manager.player._healthSystem.Heal(value);
        }

        public void RestoreHealthStartAction()
        {
            player._healthSystem.healthMax *= multiplier;
        }

        public void RestoreHealthEndAction()
        {
            player._healthSystem.healthMax/= multiplier;
        }

        public void HighSpeedStartAction()
        {
            player.moveSpeed *= multiplier;
        }

        public void HighSpeedEndAction()
        {
            player.moveSpeed /= multiplier;
        }

        public void SlowTimeStartAction()
        {
            Time.timeScale = .5f;
        }

        public void SlowTimeEndAction()
        {
            Time.timeScale = 1;
        }

        public void ImmuneStartAction()
        {
            player._healthSystem.resistDeath = true;
        }

        public void ImmuneEndAction()
        {
            player._healthSystem.resistDeath = false;
        }


    }
}