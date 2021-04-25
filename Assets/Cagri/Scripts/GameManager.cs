using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cagri.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager manager;
        public static Camera cam;
        public List<PlayerColor> defaultPlayerColors = new List<PlayerColor>();
        
        [HideInInspector]public List<PlayerColor> currentPlayerColors = new List<PlayerColor>();
        
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
            currentPlayerColors = defaultPlayerColors;
            DontDestroyOnLoad(gameObject);
        }

        
        public void ResetManager()
        {
            currentPlayerColors?.Clear();
            currentPlayerColors = defaultPlayerColors;
        }
    }
}
