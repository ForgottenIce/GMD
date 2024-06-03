using UnityEngine;

namespace Enemy.Slime.States
{
    public class SlimeIdleState : SlimeState
    {
        private float _idleStartTime;
        protected override void OnEnterState(SlimeContext context)
        {
            context.Animator.Play("slime_idle");
            _idleStartTime = Time.time;
        }

        public override void Update(SlimeContext context)
        {
            if (ShouldChargePlayer(context) || _idleStartTime + context.SlimeStats.idleDuration < Time.time)
            {
                context.PatrolOnNextStateChange = true;
                StateComplete = true;
            }
        }
    }
}