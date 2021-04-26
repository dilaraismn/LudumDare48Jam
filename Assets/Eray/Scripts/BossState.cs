using UnityEngine;

namespace Eray.Scripts
{
    public abstract class BossState : MonoBehaviour
    {
        public abstract void PlayAnimation(Animator anim);

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