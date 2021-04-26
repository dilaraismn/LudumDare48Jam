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
        public bool useMeshRenderer;
        public MeshRenderer myMeshRenderer;

        private IEnemy _enemy;
        public override void Start()
        {
            base.Start();
            _enemy = GetComponent<IEnemy>();
            
        }

        public override void Active()
        {
            base.Active();
            _enemy.OnActive();
            
            if (useMeshRenderer)
            {
                var materials = myMeshRenderer.materials;
                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = activeMaterialsList[i];
                }
                myMeshRenderer.materials = materials;
            }
            else
            {
                var materials = mySkinnedMeshRenderer.materials;
                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = activeMaterialsList[i];
                }
                mySkinnedMeshRenderer.materials = materials;
            }
            
        }

        public override void DeActive()
        {
            base.DeActive();
            _enemy.OnDeActive();
            if (useMeshRenderer)
            {
                var materials = myMeshRenderer.materials;
                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = deActiveMaterialsList[i];
                }
                myMeshRenderer.materials = materials;
            }
            else
            {
                var materials = mySkinnedMeshRenderer.materials;
                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = deActiveMaterialsList[i];
                }
                mySkinnedMeshRenderer.materials = materials;
            }
           
        }
    }
}
