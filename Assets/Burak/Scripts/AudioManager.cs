using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Burak.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        public AudioTrack[] audioTracks;

        [System.Serializable]
        public class AudioTrack
        {
            public AudioSource audioSource;
            public AudioClip[] audioClips;
        }

        private void Awake()
        {
            if (!instance)
            {
                instance = this;
            }
            DontDestroyOnLoad(this);
        }

        public void PlaySound(int audioSourceIndex, int clipIndex)
        {
            audioTracks[audioSourceIndex - 1].audioSource.clip = audioTracks[audioSourceIndex-1].audioClips[clipIndex-1];
            audioTracks[audioSourceIndex - 1].audioSource.Play();
        }

        public void StopSound(int audioSourceIndex)
        {
            audioTracks[audioSourceIndex - 1].audioSource.Stop();
        }

        // Update is called once per frame
        void Update()
        {
            /*if (Input.GetKeyDown(KeyCode.Q))
            {
                PlaySound(1, 1);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                PlaySound(1, 2);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                StopSound(1);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                PlaySound(2, 1);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                PlaySound(2, 2);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                StopSound(2);
            }*/
        }
    }
}


