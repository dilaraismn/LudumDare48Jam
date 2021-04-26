using System;
using System.Collections.Generic;
using UnityEngine;

namespace Furkan.Powerup
{
    public class PowerupController : MonoBehaviour
    {
        public static PowerupController instance;
        public GameObject powerupPrefab;
        public List<Powerup> powerups;
        public Dictionary<Powerup, float> activatePowerups = new Dictionary<Powerup, float>();

        private List<Powerup> keys = new List<Powerup>();


        private void Awake()
        {
            instance = this;
        }

        private void HandleGlobalPowerups()
        {
            bool changed = false;

            if (activatePowerups.Count > 0)
            {
                foreach (Powerup powerup in keys)
                {
                    if (activatePowerups[powerup] > 0)
                    {
                        activatePowerups[powerup] -= Time.deltaTime;
                    }
                    else
                    {
                        changed = true;

                        activatePowerups.Remove(powerup);

                        powerup.End();
                    }
                }
            }

            if (changed)
            {
                keys = new List<Powerup>(activatePowerups.Keys);
            }
        }
        public void ActivatePowerup(Powerup powerup)
        {
            if (!activatePowerups.ContainsKey(powerup))
            {
                powerup.Start();
                activatePowerups.Add(powerup, powerup.duration);
            }
            else
            {
                activatePowerups[powerup] += powerup.duration;
            }

            keys = new List<Powerup>(activatePowerups.Keys);
        }

        public void ClearActivePowerups()
        {
            foreach (KeyValuePair<Powerup, float> Powerup in activatePowerups)
            {
                Powerup.Key.End();
            }

            activatePowerups.Clear();
        }

        private void Update()
        {
            HandleGlobalPowerups();
            //TEST
            // if (Input.GetKeyDown(KeyCode.T))
            // {
            //     SpawnPowerup(powerups[UnityEngine.Random.Range(0,powerups.Count)], new Vector3(2, .5f, 2));
            // }
            // Debug.Log(powerups.Count);
            
        }

        public GameObject SpawnPowerup(Powerup powerup, Vector3 position)
        {
            GameObject powerupGameObject = Instantiate(powerupPrefab);

            var powerupBehaviour = powerupGameObject.GetComponent<PowerupBehaviour>();

            powerupBehaviour.SetPowerUp(powerup);

            powerupGameObject.transform.position = position;

            return powerupGameObject;
        }

        public GameObject SpawnRandomPowerUp(Vector3 position)
        {
            return SpawnPowerup(powerups[UnityEngine.Random.Range(0, powerups.Count - 1)], position);
        }
    }
}