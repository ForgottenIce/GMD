using UnityEngine;

namespace Player.MovementStates
{
    public class PlayerFallingState : PlayerMovementState
    {
        private bool _jumpNextFixedUpdate;
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
            if (context.InputManager.JumpPressed && context.JumpOrbCollected) _jumpNextFixedUpdate = true;
        }

        public override void FixedUpdate(PlayerContext context)
        {
            if (context.CollisionData.TouchingGround || (context.InputManager.DashHeld && context.DashAvailable))
            {
                StateComplete = true;
                return;
            }
            
            HandleMovement(context);
            HandleGravity(context);
            
            if (_jumpNextFixedUpdate)
            {
                context.JumpOrbCollected = false;
                _jumpNextFixedUpdate = false;
                HandleJump(context);
                StateComplete = true;
            }
        }
    }
}