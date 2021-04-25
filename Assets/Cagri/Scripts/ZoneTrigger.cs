using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cagri.Scripts
{
    public class ZoneTrigger : MonoBehaviour
    {
        public List<ColorObjectBase> myColorObjectList;
        
        private void OnTriggerEnter(Collider other)
        {
            TestPlayer player = other.GetComponent<TestPlayer>();
            if (player)
            {
                GetComponent<Collider>().enabled = false;
                ColorManager.manager.colorObjectsBases?.Clear();
                ColorManager.manager.colorObjectsBases = myColorObjectList;
            }
        }
    }
}