using System;
using System.Security.Permissions;
using UnityEngine;

namespace Eray.Scripts
{
    public class SpearBehaviour : MonoBehaviour
    {
        public Spear spear;
        [SerializeField] private Transform targetPoint;
        [SerializeField] private LayerMask targetLayers;
        [SerializeField] private Transform hoverHolder;

        private PlayerMovement _pm;

        private Vector3 _target;

        private Camera _camera;
        private bool _isAiming;
        private Vector3 _mousePos;
        private bool canRotate;

        
        [HideInInspector] public bool spearThrown;
        [HideInInspector] public bool moveToHand;
        private bool _hasTarget;

        public bool SpearThrown => spearThrown;

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
            if (!spearThrown)
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
                        spear.inAttackState = true;
                        _hasTarget = false;
                        spear.TargetHit = false;
                        targetPoint.gameObject.SetActive(false);
                        spear.MoveRoTarget();
                        _isAiming = false;
                        canRotate = false;
                        spearThrown = true;
                    }
                }
               
            }
            else
            {
                if (Input.GetMouseButtonDown(1))
                {
                    spear.transform.SetParent(null);
                    moveToHand = true;
                }
            }
            
            if (canRotate)
            {
                spear.RotateSpear(targetPoint);
                spear.LookTarget(targetPoint);
            }

            if (moveToHand && spear.TargetHit)
            {
                if(spear.MoveToHand())
                {
                    spearThrown = false;
                    moveToHand = false;
                }
            }
            
           
            
            if(_isAiming)
                Aim();
            
        }
    }
}