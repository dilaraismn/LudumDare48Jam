using System;
using Eray.Scripts;
using UnityEngine;

namespace Mehmethan.Scripts
{
    public class Bow : MonoBehaviour
    {
        [SerializeField] private float bowSpeed;
        public float damage;
        private void Start()
        {
            Destroy(gameObject,3f);
        }

        void Update()
        {
            transform.Translate(Vector3.forward * bowSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player)
            {
                player._healthSystem.DealDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
