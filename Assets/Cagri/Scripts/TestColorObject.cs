using UnityEngine;

namespace Cagri.Scripts
{
    public class TestColorObject : ColorObjectBase
    {
        public override void Active()
        {
            base.Active();
            gameObject.SetActive(true);
        }

        public override void DeActive()
        {
            base.DeActive();
            gameObject.SetActive(false);
        }
        
    }
}