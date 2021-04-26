using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cagri.Scripts
{
    
    public class ColorManager : MonoBehaviour
    {
        public static ColorManager manager;

        [HideInInspector] 
        public List<ColorObjectBase> colorObjectsBases = new List<ColorObjectBase>();
        
        private void Awake()
        {
            manager = this;
        }

        public void OnPlayerChangeColor()
        {
            foreach (ColorObjectBase colorObjectBase in colorObjectsBases)
            {
                foreach (PlayerColor playerColor in  GameManager.manager.currentPlayerColors )
                {
                    if (!playerColor.canUse)
                    {
                        continue; 
                    }
                    if (playerColor.colorType==colorObjectBase.currentColorType)
                    {
                        if (playerColor.isActive)
                        {
                            colorObjectBase.Active();
                        }
                        else
                        {
                            colorObjectBase.DeActive();
                        }
                    }
                }
            }
        }
        
    }
}