using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cagri.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager manager;

        
        private void Awake()
        {
            manager = this;
        }
    }
}