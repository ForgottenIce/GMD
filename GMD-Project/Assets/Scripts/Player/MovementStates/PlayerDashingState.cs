using UnityEngine;

namespace Player.MovementStates
{
    public class PlayerDashingState : PlayerMovementState
    {
        private float _dashUsedTime;
        protected override void OnEnterState(PlayerContext context)
        {
            context.Animator.Play("player_dash");
            var dashAudioClip = context.AudioClips.GetClip("player_dash");
            context.AudioSource.PlayOneShot(dashAudioClip);
            
            _dashUsedTime = Time.time;
            var currentVelocity = context.RigidBody.velocity;
            var dashDirection = context.RigidBody.transform.localScale.x < 0 ? -1 : 1;
            currentVelocity.x = context.PlayerStats.dashPower * dashDirection;
            currentVelocity.y = 0;
            context.RigidBody.velocity = currentVelocity;
            
            context.DashAvailable = false;
        }

        public override void FixedUpdate(PlayerContext context)
        {
            if (_dashUsedTime + context.PlayerStats.dashDuration < Time.time)
            {
                StateComplete = true;
            }
            
            var currentVelocity = context.RigidBody.velocity;
            currentVelocity.y = 0;
            
            context.RigidBody.velocity = currentVelocity;
        }
    }
}