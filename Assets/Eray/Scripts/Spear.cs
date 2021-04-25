using System;
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

        private bool _isFired;

        public void LookTarget(Transform target)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            var lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            //lookRotation = Quaternion.Euler(lookRotation.eulerAngles.x, transform.localEulerAngles.y, lookRotation.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        }
        
        
        public void MoveRoTarget()
        {
            transform.parent = null;
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.velocity = transform.forward * speed;
            _isFired = true;

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

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                _isFired = false;
                rb.velocity = Vector3.zero;
                rb.useGravity = false;
                rb.isKinematic = true;
            }
        }

        private void UseRbConstrains()
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        
    }
}