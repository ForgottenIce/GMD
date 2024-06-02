using UnityEngine;

namespace Player.MovementStates
{
    public class PlayerIdleState : PlayerMovementState
    {
        protected override void OnEnterState(PlayerContext context)
        {
            context.RigidBody.velocity = new Vector2(0, 0);
            context.Animator.Play("player_idle");
            
            context.DashAvailable = true;
            context.JumpOrbCollected = false;
        }

        public override void Update(PlayerContext context)
        {
            if (!context.CollisionData.TouchingGround || context.PlayerInput.MoveDirection != 0 || context.PlayerInput.DashPressed)
            {
                StateComplete = true;
            }
            
            if (context.PlayerInput.JumpPressed)
            {
                HandleJump(context);
            }
        }
    }
}