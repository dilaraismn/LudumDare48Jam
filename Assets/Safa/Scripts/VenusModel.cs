using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Safa.Scripts
{

    public class VenusModel : MonoBehaviour
    {

        public Enemy enemy;




        public void Attack ()
        {
            enemy.RangedAttack();

        }





    }

}


