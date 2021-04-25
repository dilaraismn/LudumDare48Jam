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
        [SerializeField] Transform headPivot;
        [SerializeField] float yOffset;
        HealthSystem healthSystem;
        
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
                return;

            }

            if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
            {
                var dir = player.transform.position - bullet.transform.position;
                _attackTimer += Time.deltaTime;
                headPivot.transform.localRotation = Quaternion.Lerp(headPivot.localRotation, Quaternion.LookRotation(dir.normalized), Time.deltaTime * 5);
                
                if (_attackTimer >= attackSpeed)
                {
                    _attackTimer = 0f;
                    RangedAttack();
                }
            }
        }


        public void RangedAttack()
        {
            var clone = Instantiate(bullet,bulletPoint);
            clone.transform.SetParent(transform.parent);
        }
        
    }


}





