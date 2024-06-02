using UnityEngine;

namespace Player.MovementStates
{
    public class PlayerFallingState : PlayerMovementState
    {
        protected override void OnEnterState(PlayerContext context)
        {
            context.Animator.Play("player_fall");
            var currentVelocity = context.RigidBody.velocity;
            currentVelocity.y *= context.PlayerStats.jumpReleaseMultiplier;
            context.RigidBody.velocity = currentVelocity;
            context.JumpPadUsed = false;
        }

        public override void Update(PlayerContext context)
        {
            
        }

        public override void FixedUpdate(PlayerContext context)
        {
            if (context.CollisionData.TouchingGround || (context.PlayerInput.DashHeld && context.DashAvailable))
            {
                StateComplete = true;
                return;
            }
            
            HandleMovement(context);
            HandleGravity(context);
        }
    }
}