using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gokhan.Scripts
{
    public class HexagonMove : MonoBehaviour
    {

        public Transform r1, r2;
        Vector3 v1, v2;
        public float Speed;
        bool onV1, onV2;
        void Awake()
        {
            r1 = transform.GetChild(0).gameObject.transform;
            r2 = transform.GetChild(1).gameObject.transform;
            onV1 = true;
            v1 = r1.position;
            v2 = r2.position;
        }

        // Update is called once per frame
        void Update()
        {


            if (transform.position != v1 && onV1 == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, v1, Time.deltaTime * Speed);
                if (transform.position == v1)
                {
                    onV1 = true;
                    onV2 = false;
                }
            }
            if (transform.position != v2 && onV2 == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, v2, Time.deltaTime * Speed);
                if (transform.position == v2)
                {
                    onV2 = true;
                    onV1 = false;
                }
            }

        }
    }
}