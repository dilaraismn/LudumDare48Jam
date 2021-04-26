using System;
using Burak.Scripts;
using Cagri.Scripts;
using UnityEngine;

namespace Eray.Scripts
{
    public class BossTrigger : MonoBehaviour
    {
        [SerializeField] private Boss boss;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerMovement>())
            {
                boss.SetPlayer(other.gameObject.transform);
                AudioManager.instance.PlaySound(0,1);
                Destroy(gameObject);
            }
        }
    }
}