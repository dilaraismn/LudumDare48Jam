using UnityEngine;

namespace Eray.Scripts
{
    public class BossState : MonoBehaviour
    {
        public virtual void PlayAnimation(Animator anim) {}

    }

    public class MoveState : BossState
    {
        public override void PlayAnimation(Animator anim)
        {
            anim.SetTrigger("isMoving");
        }
    }

    public class ScreamState : BossState
    {
        public override void PlayAnimation(Animator anim)
        {
            anim.SetTrigger("isScreaming");
        }
    }

    public class AttackState : BossState
    {
        public override void PlayAnimation(Animator anim)
        {
            anim.SetTrigger("isAttacking");
        }
    }

    public class IdleState : BossState
    {
        public override void PlayAnimation(Animator anim)
        {
            anim.SetTrigger("isIdle");
        }
    }
    
    
}