using System;
using System.Collections;
using System.Collections.Generic;
using Cagri.Scripts;
using Eray.Scripts;
using Unity.Mathematics;
using UnityEngine;


namespace Safa.Scripts
{
    
    public class Enemy : MonoBehaviour,IEnemy
    {
        PlayerMovement player;
        [SerializeField] GameObject bullet;
        [SerializeField] Transform bulletPoint;
        [SerializeField] private float timeBetweenAttacks;
        [SerializeField] public float attackRange;
        [SerializeField] private float attackSpeed = 3f;
         Transform targetPoint;
        [SerializeField] float yOffset;
        public Animator anim;
        
        private float _attackTimer = 0f;
        [HideInInspector]public HealthSystem healthSystem;



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
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            healthSystem.onDeath -= Enemy_onDeath;

        }



        public virtual void Start()
        {
            player = LevelManager.manager.player;

            
            
            
            
            

        }

       

        private void Update()
        {
            if (!_isActive)
            {
                return;
            }

            if (!player)
            {
                anim.SetBool("attack", false);

                return;


            }

            if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
            {
                var attackDir = player.cameraTarget.transform.position - bulletPoint.transform.position;
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

        public void OnPlayerHit()
        {
            healthSystem.DealDamage(LevelManager.manager.player.playerDamage);
        }

        private bool _isActive=true;
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





