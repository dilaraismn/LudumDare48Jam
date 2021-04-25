using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sevval
{
    [System.Serializable]
    public class ItemToSpawn
    {
        public GameObject item;
        public float spawnRate;
        [HideInInspector]
        public float minSpawnProb, maxSpawnProb;
    }

    public class LootSystem : MonoBehaviour
    {
        public ItemToSpawn[] itemToSpawn;
        public Transform positionToSpawn;

        private void Start()
        {
            for (int i = 0; i < itemToSpawn.Length; i++)
            {
                if (i == 0)
                {
                    itemToSpawn[i].minSpawnProb = 0;
                    itemToSpawn[i].maxSpawnProb = itemToSpawn[i].spawnRate - 1;
                }
                else
                {
                    itemToSpawn[i].minSpawnProb = itemToSpawn[i - 1].maxSpawnProb + 1;
                    itemToSpawn[i].maxSpawnProb = itemToSpawn[i].minSpawnProb + itemToSpawn[i].spawnRate - 1;
                }
            }
            //  Spawner(); test

        }


        void Spawner()
        {
            float randomNum = Random.Range(0, 100);
            for (int i = 0; i < itemToSpawn.Length; i++)
            {
                if (randomNum >= itemToSpawn[i].minSpawnProb && randomNum <= itemToSpawn[i].maxSpawnProb)
                {
                    Instantiate(itemToSpawn[i].item, positionToSpawn.position, Quaternion.identity);
                    break;
                }
            }
        }
    }
}