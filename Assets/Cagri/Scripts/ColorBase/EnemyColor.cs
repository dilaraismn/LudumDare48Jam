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
            _enemy.OnDeActive();
            var materials = mySkinnedMeshRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = deActiveMaterialsList[i];
            }
            mySkinnedMeshRenderer.materials = materials;
        }
    }
}
