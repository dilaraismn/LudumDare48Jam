using System;
using UnityEngine;

namespace Cagri.Scripts
{
    [Serializable]
    public class PlayerColor
    {
        public ColorObjectBase.ColorType colorType;
        public bool isActive;
        public bool canUse;
        public KeyCode myKeyCode;
    }
    public class PlayerColorController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                
            } 
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                
            }
        }

        private void ColorControl()
        {
        }

    }
}