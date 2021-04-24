using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Eray.Scripts
{
    public class HeadMovement : MonoBehaviour
    {
        [SerializeField] private Transform head;
        [SerializeField] private Transform bulletPoint;
        [SerializeField] private GameObject bulletPrefab;

        private bool _hasPlayer;
        private GameObject _player;
        private float _timer;
        private Vector3 dir;


        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_hasPlayer)
            {
                dir = _player.transform.position - head.position;
                head.rotation = Quaternion.Lerp(head.rotation, Quaternion.LookRotation(dir.normalized),
                    Time.deltaTime * 5);

                if (_timer < 0f)
                {
                    Fire();
                    _timer = 3;
                }

            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerMovement>())
            {
                _hasPlayer = true;
                _player = other.gameObject;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerMovement>())
            {
                _hasPlayer = false;
            }
        }

        private void Fire()
        {
            Instantiate(bulletPrefab, bulletPoint.position, head.rotation);
        }
    }
}
