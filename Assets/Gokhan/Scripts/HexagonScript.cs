using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gokhan.Scripts
{
    public class HexagonScript : MonoBehaviour
    {

        public GameObject colorBase;
        GameObject player;

        private void Awake()
        {
            colorBase = transform.parent.gameObject;

        }
        private void FixedUpdate()
        {
            if (!colorBase.activeSelf)
            {

                Invoke("ParentFormat", 2);
            }

        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<GameMechanicManager>())
            {
                collision.transform.SetParent(transform);
                transform.SetParent(null);
                player = collision.gameObject;
            }


        }
        void ParentFormat()
        {
            gameObject.transform.SetParent(colorBase.transform);
            player.transform.SetParent(null);

        }
        private void OnCollisionExit(Collision collision)
        {
            ParentFormat();
        }
        public GameObject GetParentName()
        {
            return transform.transform.parent.gameObject;
        }

    }
}