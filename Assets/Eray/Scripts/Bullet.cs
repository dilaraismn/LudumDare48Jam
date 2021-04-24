using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Eray.Scripts
{
    public class Bullet : MonoBehaviour
    {
        private void Update()
        {
           //transform.position += transform.forward * (Time.deltaTime * 4);
           transform.Translate(transform.forward * (Time.deltaTime * 4), Space.World);
        }
    }
}