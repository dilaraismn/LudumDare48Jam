using System;
using Burak.Scripts;
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
                ColorControl(KeyCode.Alpha1,0);
                
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ColorControl(KeyCode.Alpha2,1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ColorControl(KeyCode.Alpha3,2);
            } 
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ColorControl(KeyCode.Alpha4,3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                ColorControl(KeyCode.Alpha5,4);
            }
        }

        private void ColorControl(KeyCode targetKey,int UIIndex)
        {
            foreach (PlayerColor currentPlayerColor in GameManager.manager.currentPlayerColors)
            {
                if (currentPlayerColor.myKeyCode==targetKey)
                {
                    currentPlayerColor.isActive = !currentPlayerColor.isActive;
                    if (currentPlayerColor.isActive)
                    {
                        UIManager.instance.SetUIColorByIndex(UIIndex,2);
                    }
                    else
                    {
                        UIManager.instance.SetUIColorByIndex(UIIndex,1);
                    }
                    ColorManager.manager.OnPlayerChangeColor();
                    break;
                }
            }
            
        }

    }
}