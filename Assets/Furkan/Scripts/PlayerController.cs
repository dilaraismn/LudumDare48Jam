using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Furkan.Powerup
{
    public class PlayerController : MonoBehaviour
    {
        private const string VERTICAL_AXIS_KEY = "Vertical";
        private const string HORIZONTAL_AXIS_KEY = "Horizontal";

        private Rigidbody rigidBody;

        public float health;
        public float speed;
        public bool takeDamage;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            float hInputAxis = Input.GetAxis(HORIZONTAL_AXIS_KEY);
            float vInputAxis = Input.GetAxis(VERTICAL_AXIS_KEY);

            Vector3 movement =
                new Vector3(hInputAxis * speed, 0, vInputAxis * speed);

            Vector3 nextPosition = transform.position + movement * Time.deltaTime;

            rigidBody.velocity = movement;
        }
    }
}
