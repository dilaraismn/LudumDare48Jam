using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Furkan.Powerup
{
    public class PowerupActions : MonoBehaviour
    {
        [SerializeField]
        PlayerController player;

        float multiplier = 1.3f;

        public void RestoreHealthStartAction()
        {
            player.health *= multiplier;
        }

        public void RestoreHealthEndAction()
        {
            player.health /= multiplier;
        }

        public void HighSpeedStartAction()
        {
            player.speed *= multiplier;
        }

        public void HighSpeedEndAction()
        {
            player.speed /= multiplier;
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
            player.takeDamage = false;
        }

        public void ImmuneEndAction()
        {
            player.takeDamage = true;
        }


    }
}