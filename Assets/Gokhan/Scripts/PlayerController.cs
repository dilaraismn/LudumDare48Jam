using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gokhan.Scripts
{
    public class PlayerController : MonoBehaviour
    {
      
        [Range(0, 10)]
        public float Hiz;
        Rigidbody rbody;



       void Awake()
        {
         
            rbody = GetComponent<Rigidbody>();
           
        }  

        void FixedUpdate()
        {
           
            Move();
        }


        //Hareket Komutları
        void Move()
        {
            rbody.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * Hiz, +0.01f, Input.GetAxis("Vertical") * Time.fixedDeltaTime * Hiz), Space.Self);
            if (Input.GetKey(KeyCode.Space))
            {
                rbody.transform.Translate(new Vector3(0, +Hiz * Time.fixedDeltaTime, 0), Space.Self);
            }
        }


    }
}
