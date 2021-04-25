using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


namespace Safa.Scripts
{
    
    public class Enemy : MonoBehaviour
    {
        Player player;
        [SerializeField] GameObject bullet;
        [SerializeField] Transform bulletPoint;
        [SerializeField] private float timeBetweenAttacks;
        [SerializeField] public float attackRange;
        [SerializeField] private float attackSpeed = 3f;
        [SerializeField] Transform targetPoint;
        [SerializeField] float yOffset;
        HealthSystem healthSystem;
        public Animator anim;
        
        private float _attackTimer = 0f;



        private void Awake()
        {
            healthSystem = GetComponent<HealthSystem>();
            



        }


        private void OnEnable()
        {
            healthSystem.onDeath += Enemy_onDeath;
        }

        private void Enemy_onDeath()
        {
            Debug.Log("Enemy died");
        }

        private void OnDisable()
        {
            healthSystem.onDeath -= Enemy_onDeath;

        }



        public virtual void Start()
        {
            player = FindObjectOfType<Player>();

            
           


            if (!player)
            {
                Destroy(gameObject);
            }
            
            
            

        }

       

        private void Update()
        {


            if (!player)
            {
                anim.SetBool("attack", false);

                return;


            }

            if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
            {
                var attackDir = player.targetPoint.transform.position - bulletPoint.transform.position;
                var dir = player.transform.position - bulletPoint.transform.position;

              bulletPoint.transform.rotation = Quaternion.LookRotation(attackDir);

              transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(dir.normalized), Time.deltaTime * 5);




                anim.SetBool("attack", true);



            } else
            {
                anim.SetBool("attack", false);

            }
        }


        public void RangedAttack()
        {
            var clone = Instantiate(bullet,bulletPoint);
            clone.transform.SetParent(transform.parent);
        }
        
    }


}





