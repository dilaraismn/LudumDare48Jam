﻿using System;
using System.Security.Permissions;
using UnityEngine;

namespace Eray.Scripts
{
    public class SpearBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform spearHolder;
        [SerializeField] private Spear spear;
        [SerializeField] private Transform targetPoint;
        [SerializeField] private LayerMask targetLayers;
        [SerializeField] private Transform hoverHolder;

        private Vector3 _target;

        private Camera _camera;
        private bool _isAiming;
        private Vector3 _mousePos;
        private bool canRotate;

        private void Start()
        {
            _camera = Camera.main;
        }


        private void Throw()
        {
            
            
        }

        private void Pull()
        {
            
        }

        private void Aim()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, targetLayers))
            {
                targetPoint.position = raycastHit.point;
            }
        }

        private void Update()
        {
            if (canRotate)
            {
                spear.RotateSpear(targetPoint);
                spear.LookTarget(targetPoint);
            }

            if (Input.GetMouseButtonDown(1))
            {
                spear.transform.parent = hoverHolder;
                spear.transform.position = hoverHolder.position;
                targetPoint.gameObject.SetActive(true);
                _isAiming = true;
                canRotate = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                targetPoint.gameObject.SetActive(false);
                spear.MoveRoTarget();
                _isAiming = false;
                canRotate = false;
            }
            
            if(_isAiming)
                Aim();
            
        }
    }
}