using System;
using UnityEngine;

namespace Mehmethan.Scripts
{
    public class Bow : MonoBehaviour
    {
        [SerializeField] private float bowSpeed;
        private void Start()
        {
            Destroy(gameObject,3f);
        }

        void Update()
        {
            transform.Translate(Vector3.forward * bowSpeed * Time.deltaTime);
        }
    
    
    }
}
