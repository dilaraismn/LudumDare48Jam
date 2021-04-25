using System;
using UnityEngine;

namespace Cagri.Scripts
{
   
    public abstract class ColorObjectBase : MonoBehaviour
    {
        public enum ColorType
        {
            Color1,
            Color2,
            Color3,
            Color4,
            Color5
        }
        public ColorType currentColorType;

        private bool _isActive;

        

        public virtual void Start()
        {
            
        }

        public virtual void Active()
        {
            if (_isActive)
            {
                return;
            }
            _isActive = true;
        }

        public virtual void DeActive()
        {
            if (!_isActive)
            {
                return;
            }
            _isActive = false;
        }
        
        //todo yeni renk toplandiginda playera haber verecek ve o renk kullanilabilir olacak 
        
        //todo ColorManager  
        
        //todo Color objectBase SetColor yazilabilir 

        //todo 

        //todo 

        //todo 

        //todo 

        //todo 

        //todo 

    }
}
