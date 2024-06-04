using UnityEngine;

namespace Enemy.Slime.States
{
    public class SlimeChargingState : SlimeState
    {
        private float _chargeUsedTime;
        protected override void OnEnterState(SlimeContext context)
        {
            context.Animator.Play("slime_charge");
            var chargeAudioClip = context.AudioClips.GetClip("slime_charge");
            context.AudioSource.PlayOneShot(chargeAudioClip);
            
            _chargeUsedTime = Time.time;
            ChargeTowardsPlayer(context);
        }

        public override void Update(SlimeContext context)
        {
            if (_chargeUsedTime + context.SlimeStats.chargeDuration < Time.time)
            {
                context.PatrolOnNextStateChange = true;
                StateComplete = true;
            }
        }

        private static void ChargeTowardsPlayer(SlimeContext context)
        {
            var chargeDirection = context.PlayerRigidBody.position - context.RigidBody.position;
            chargeDirection = chargeDirection.normalized;
            chargeDirection.y += context.SlimeStats.chargeYOffset;
            context.RigidBody.velocity = chargeDirection * context.SlimeStats.chargeSpeed;

            var directionToFace = chargeDirection.x > 0 ? 1 : -1;
            var localScale = context.RigidBody.transform.localScale;
            localScale.x = Mathf.Abs(localScale.x) * directionToFace;
            context.RigidBody.transform.localScale = localScale;
        }
    }
}