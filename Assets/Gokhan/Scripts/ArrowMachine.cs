using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gokhan.Scripts
{
    public class ArrowMachine : MonoBehaviour
    {
        public Transform TargetPoint, LastPoint;

        public float Speed;
        public GameObject Arrow;
        Transform StartPoint;
        void Start()
        {
            StartPoint = transform;

        }

        // Update is called once per frame
        void Update()
        {
            if (Arrow.transform.position != TargetPoint.position)
            {
                //Instantiate(Arrow, StartPoint);
                Arrow.transform.position = Vector3.MoveTowards(Arrow.transform.position, TargetPoint.position, Time.deltaTime * Speed);

            }
            if (Arrow.transform.position == LastPoint.position|| Arrow.transform.position == TargetPoint.position)
            {
                Arrow.transform.position = StartPoint.position;
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<HexagonScript>())
            {
                Destroy(Arrow);
                
            }
        }
      
    }
}