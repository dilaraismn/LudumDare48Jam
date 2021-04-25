using System;
using System.Security.Permissions;
using UnityEngine;

namespace Eray.Scripts
{
    public class SpearBehaviour : MonoBehaviour
    {
        [SerializeField] private Spear spear;
        [SerializeField] private Transform targetPoint;
        [SerializeField] private LayerMask targetLayers;
        [SerializeField] private Transform hoverHolder;

        private PlayerMovement _pm;

        private Vector3 _target;

        private Camera _camera;
        private bool _isAiming;
        private Vector3 _mousePos;
        private bool canRotate;

        
        private bool _spearThrown;
        private bool _moveToHand;
        private bool _hasTarget;

        public bool SpearThrown => _spearThrown;

        private void Awake()
        {
            _pm = GetComponent<PlayerMovement>();
        }

        private void Start()
        {
            _camera = Camera.main;
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
            if (!_spearThrown)
            {
                if (_pm.IsAttacking == false)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        spear.transform.parent = hoverHolder;
                        spear.transform.position = hoverHolder.position;
                        targetPoint.gameObject.SetActive(true);
                        _isAiming = true;
                        canRotate = true;
                        _hasTarget = true;
                    }

                    if (Input.GetMouseButtonUp(1) && _hasTarget)
                    {
                        _hasTarget = false;
                        spear.TargetHit = false;
                        targetPoint.gameObject.SetActive(false);
                        spear.MoveRoTarget();
                        _isAiming = false;
                        canRotate = false;
                        _spearThrown = true;
                    }
                }
               
            }
            else
            {
                if (Input.GetMouseButtonDown(1))
                {
                    spear.transform.SetParent(null);
                    _moveToHand = true;
                }
            }
            
            if (canRotate)
            {
                spear.RotateSpear(targetPoint);
                spear.LookTarget(targetPoint);
            }

            if (_moveToHand && spear.TargetHit)
            {
                if(spear.MoveToHand())
                {
                    _spearThrown = false;
                    _moveToHand = false;
                }
            }
            
           
            
            if(_isAiming)
                Aim();
            
        }
    }
}