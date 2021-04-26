using System;
using System.Collections;
using System.Text;
using Cagri.Scripts;
using Safa.Scripts;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Eray.Scripts
{
    public class Spear : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed;
        [SerializeField] private float turnSpeed;
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private Transform spearHolder;

        private Vector3 _localPos;

        private bool _isFired;
        private bool _onHand;

        public bool TargetHit;

        public bool inAttackState;

        private void OnEnable()
        {
            _localPos = transform.localPosition;
        }

        public void LookTarget(Transform target)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            var lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            //lookRotation = Quaternion.Euler(lookRotation.eulerAngles.x, transform.localEulerAngles.y, lookRotation.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        }
        
        
        public void MoveRoTarget()
        {
            _onHand = false;
            transform.parent = null;
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.velocity = transform.forward * speed;
            _isFired = true;

            StartCoroutine("WaitForReturn");

        }

        public bool MoveToHand()
        {
            if (_onHand == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, spearHolder.position, Time.deltaTime * speed);
                transform.rotation = Quaternion.Slerp(transform.rotation, spearHolder.rotation, Time.deltaTime * .5f);
                
                if (transform.position == spearHolder.position)
                {
                    transform.rotation = spearHolder.rotation;
                    transform.SetParent(spearHolder);
                    transform.localPosition = _localPos;
                    transform.localScale = Vector3.one;
                    _onHand = true;
                    return _onHand;
                }
            }

            return _onHand;
        }

        public float? RotateSpear(Transform target)
        {
            
            float? angle = CalculateAngle(true, target);
        
            if (angle != null)
            {
                transform.localEulerAngles = new Vector3(360f - (float) angle, 
                    transform.localEulerAngles.y, transform.localEulerAngles.z);
            }
        
            return angle;
        }
        
        private float? CalculateAngle(bool low, Transform target)
        {
            Vector3 direction = target.position - transform.position;
            float y = direction.y;
            direction.y = 0f;
            float x = direction.magnitude;
            float gravity = Physics.gravity.magnitude;
            float speedSqr = Mathf.Pow(speed, 2);
            float underSqrRoot = (Mathf.Pow(speedSqr, 2) - gravity * (gravity * Mathf.Pow(x, 2) + 2 * y * speedSqr));
        
            if (underSqrRoot >= 0)
            {
                float root = Mathf.Sqrt(underSqrRoot);
                float highAngle = speedSqr + root;
                float lowAngle = speedSqr - root;
        
                if (low)
                    return Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg;
                
                return Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg;
        
            }
        
            return null;
        }

        private void LateUpdate()
        {
            if (_isFired)
                transform.forward = rb.velocity;
        }

        private void OnTriggerEnter(Collider other)
        {
            bool canParent = true;
            HealthSystem hs;
            IEnemy? enemy = other.GetComponent<IEnemy>();
            if (enemy!=null || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                hs = other.GetComponent<HealthSystem>();
                if (hs && hs.currentHealth - LevelManager.manager.player.playerDamage <= 0)
                    canParent = false;
                if (inAttackState)
                {
                    inAttackState = false;
                    if(enemy!=null)
                        enemy.OnPlayerHit();
                }
                if (canParent && _isFired)
                {
                    _isFired = false;
                    rb.velocity = Vector3.zero;
                    rb.useGravity = false;
                    rb.isKinematic = true;
                    TargetHit = true;
                    transform.SetParent(other.gameObject.transform);
                }
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                if (_isFired)
                {
                    _isFired = false;
                    rb.velocity = Vector3.zero;
                    rb.useGravity = false;
                    rb.isKinematic = true;
                    TargetHit = true;
                    transform.SetParent(other.gameObject.transform);
                }
            }
   
        }

        IEnumerator WaitForReturn()
        {
            yield return new WaitForSeconds(4f);

            if (TargetHit == false)
            {
                TargetHit = true;
                rb.velocity = Vector3.zero;
                rb.useGravity = false;
                rb.isKinematic = true;
                _isFired = false;
            }
        }

    }
}