using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Safa.Scripts
{



    public class Enemy : MonoBehaviour
    {
        Transform player;



        [SerializeField] GameObject bullet;
        [SerializeField] GameObject bulletPoint;
        [SerializeField] private float timeBetweenAttacks;
        [SerializeField] public float attackRange;
        private float attackSpeed;
        [SerializeField] Transform headPivot;
        [SerializeField] float yOffset;
        






        public virtual void Start()
        {
            player = GameObject.FindObjectOfType<Player>().transform;
            



        }

        private void Update()
        {
            
            if (player != null)
            {
                if (Vector3.Distance(transform.position, player.position) < attackRange)
                {
                    var dir = player.position - headPivot.position;


                    headPivot.transform.rotation = Quaternion.Lerp(headPivot.rotation, Quaternion.LookRotation(dir.normalized), Time.deltaTime * 4);


                    if (Time.time >= attackSpeed)
                    {

 

                        attackSpeed = Time.time + timeBetweenAttacks;
                        RangedAttack();
                        // Start attacking..

                    }

                } else
                {

                    // Do nothing..
                }

                

            }

        }


        public void RangedAttack()
        {



            var clone = Instantiate(bullet, bulletPoint.transform);

            clone.transform.SetParent(transform.parent);



        }










    }


}





