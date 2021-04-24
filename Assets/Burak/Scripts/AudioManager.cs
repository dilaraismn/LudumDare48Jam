using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Burak.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        private void Awake()
        {
            if (!instance)
            {
                instance = this;
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


