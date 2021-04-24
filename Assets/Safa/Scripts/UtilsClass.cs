using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Safa.Scripts
{

    public class UtilsClass : MonoBehaviour
    {

        public static float GetAngleFromVector(Vector3 vector)
        {
            float radians = Mathf.Atan2(vector.y, vector.x);
            float degrees = radians * Mathf.Rad2Deg;
            return degrees;

        }



    }



}


