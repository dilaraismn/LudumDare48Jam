using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cagri.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager manager;
        public static Camera cam;
        

        private int _currentLevelIndex;

        private void Awake()
        {
            if (manager)
            {
                Destroy(gameObject);
                return;
            }
            cam=Camera.main;
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
