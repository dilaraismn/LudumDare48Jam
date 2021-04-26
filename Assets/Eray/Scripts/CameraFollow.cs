using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Eray.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        [SerializeField] private float distance;
        [SerializeField] private float maxHeight;
        [SerializeField] private float minHeight;
        [SerializeField] private bool inverseY;
        private float height;

        [SerializeField] private float rotationDamping;
        [SerializeField] private float heightDamping;
        
        

        private Vector3 mousePos;
        private Camera _cam;
        private float maxVal;
        private float minVal;

        private void Awake()
        {
            _cam = Camera.main;
        }

        private void Update()
        {
            mousePos = Input.mousePosition;



            var val = (mousePos.y / Screen.height) * maxHeight;
            

            if (!inverseY)
            {
                val = Mathf.Abs(val - maxHeight);
            }
            
            if (val < minHeight)
                val = minHeight;

            
            height = val;

        }

        void LateUpdate()
        {
            if (!target)
                return;
            
            var targetRotAngle = target.eulerAngles.y;
            var positionY = target.position.y + height;

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
    }
}