using System.Collections;
using UnityEngine;

namespace Player.MovementStates
{
    public class PlayerMovingState : PlayerMovementState
    {
        private bool _jumpNextFixedUpdate;
        private bool _dashWasPressed;
        protected override void OnEnterState(PlayerContext context)
        {
            context.Animator.Play("player_walk");
            _dashWasPressed = false;
            context.DashAvailable = true;
            context.JumpOrbCollected = false;
        }

        public override void Update(PlayerContext context)
        {
            if (context.InputManager.JumpPressed) _jumpNextFixedUpdate = true;
            if (context.InputManager.DashPressed) _dashWasPressed = true;
        }

        public override void FixedUpdate(PlayerContext context)
        {
            if (!context.CollisionData.TouchingGround || context.InputManager.MoveDirection == 0 || _dashWasPressed)
            {
                //TODO: Find a way to start a coroutine from the state machine
                //StartCoroutine(TemporarilyActivateCoyoteTime(context));
                
                // Handle any last buffered jump inputs
                if (_jumpNextFixedUpdate) HandleJump(context);
                
                StateComplete = true;
                return;
            }
            
            HandleMovement(context);

            var currentSpeed = context.RigidBody.velocity;
            currentSpeed.y = 0;
            context.RigidBody.velocity = currentSpeed;
            
            if (_jumpNextFixedUpdate)
            {
                HandleJump(context);
                _jumpNextFixedUpdate = false;
            }
        }
        
        private IEnumerator TemporarilyActivateCoyoteTime(PlayerContext context)
        {
            context.CoyoteTimeActive = true;
            yield return new WaitForSeconds(context.PlayerStats.coyoteTime);
            context.CoyoteTimeActive = false;
        }
    }
}