﻿using UnityEngine;

namespace Eray.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        [SerializeField] private float distance;
        [SerializeField] private float height;

        [SerializeField] private float rotationDamping;
        [SerializeField] private float heightDamping;
        
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