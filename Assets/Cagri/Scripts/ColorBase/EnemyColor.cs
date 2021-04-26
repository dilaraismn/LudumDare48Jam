using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Cagri.Scripts.ColorBase
{
    public class EnemyColor : ColorObjectBase
    {
        public List<Material> activeMaterialsList;
        public List<Material> deActiveMaterialsList;

        public SkinnedMeshRenderer mySkinnedMeshRenderer;
        private Rigidbody _rb;
        private NavMeshAgent _agent;
        public override void Start()
        {
            base.Start();
            _rb=GetComponent<Rigidbody>();
            _agent = GetComponent<NavMeshAgent>();

        }

        public override void Active()
        {
            base.Active();
            if (_rb)
            {
                _rb.isKinematic = true;
            }
            if (_agent)
            {
                _agent.enabled = true;
            }
            var materials = mySkinnedMeshRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = activeMaterialsList[i];
            }
            mySkinnedMeshRenderer.materials = materials;
        }

        public override void DeActive()
        {
            base.DeActive();
            if (_rb)
            {
               _rb.isKinematic = false;
            }
            if (_agent)
            {
                _agent.enabled = false;
            }
            var materials = mySkinnedMeshRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = deActiveMaterialsList[i];
            }
            mySkinnedMeshRenderer.materials = materials;
        }
    }
}
