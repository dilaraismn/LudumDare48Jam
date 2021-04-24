using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Safa.Scripts
{
    public class Bullet : MonoBehaviour
    {

        private Player playerScript;
        private Vector3 targetPosition;

        [SerializeField] private float bulletSpeed;

        private void Start()
        {
            Destroy(gameObject, 5f);

        }

        private void Update()
        {

            transform.Translate(transform.forward * bulletSpeed * Time.deltaTime);



        }

        private void OnTriggerEnter(Collider other)
        {

            var player = other.GetComponent<Player>();

            if (player)
            {
                Debug.Log("Enemy got hit!");
                Destroy(gameObject);
            }


           
        }



    }

}


