using System;
using System.Text;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Eray.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;


        public bool switchToTopDown;
        [Header("Topdown Camera")]
        [SerializeField] private float distanceTD;
        [SerializeField] private float heightTD;
        
        [Header("Backward Camera")]
        [SerializeField] private float distance;
        [SerializeField] private float maxHeight;
        [SerializeField] private float minHeight;
        [SerializeField] private bool inverseY;

        [SerializeField] private float rotationDamping;
        [SerializeField] private float heightDamping;


        [field: SerializeField] public float Height; 

        private float _height;
        private Vector3 _mousePos;
        private float _screenHeight;
        private bool topDownView;
        private float tpDistance;

        private void Awake()
        {
            _screenHeight = Screen.height;
            tpDistance = distance;
        }

        private void Update()
        {
            if (switchToTopDown)
            {
                switchToTopDown = false;
                SwitchToTopDown();
            }
            
            if (!topDownView)
            {
                _mousePos = Input.mousePosition;
                Height = _height;



                var val = (_mousePos.y / _screenHeight) * maxHeight;
            

                if (!inverseY)
                {
                    val = Mathf.Abs(val - maxHeight);
                }

                val = val < minHeight ? minHeight : val;

            
                _height = val;
            }
        }

        void LateUpdate()
        {
            if (!target)
                return;
            
            var targetRotAngle = target.eulerAngles.y;
            var positionY = target.position.y + _height;

            var currentRotationAngle = transform.eulerAngles.y;
            var currentHeight = transform.position.y;
            
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, targetRotAngle, rotationDamping * Time.deltaTime);
            
            currentHeight = Mathf.Lerp(currentHeight, positionY, heightDamping * Time.deltaTime);
            
            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
            
            transform.position = target.position;
            transform.position -= currentRotation * Vector3.forward * distance;
            
            transform.position = new Vector3(transform.position.x ,currentHeight , transform.position.z);
            
            transform.LookAt(target);
        }

        public void SwitchToTopDown()
        {
            topDownView = true;
            _height = heightTD;
            distance = distanceTD;
        }

        public void BackToThirdPerson()
        {
            topDownView = false;
            distance = tpDistance;
        }
        
    }
}