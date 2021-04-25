using System;
using System.Collections.Generic;
using Eray.Scripts;
using UnityEngine;

namespace Cagri.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager manager;
        public PlayerMovement player;
        
        private void Awake()
        {
            manager = this;
        }
    }
}
