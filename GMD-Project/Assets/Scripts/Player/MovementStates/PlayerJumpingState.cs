namespace Player.MovementStates
{
    public class PlayerJumpingState : PlayerMovementState
    {
        protected override void OnEnterState(PlayerContext context)
        {
            context.Animator.Play("player_jump");
            var jumpAudioClip = context.AudioClips.GetClip("player_jump");
            context.AudioSource.PlayOneShot(jumpAudioClip);
        }

        public override void FixedUpdate(PlayerContext context)
        {
            if (context.CollisionData.TouchingGround || context.RigidBody.velocity.y <= 0 || context.InputManager.DashHeld || (!context.InputManager.JumpHeld && !context.JumpPadUsed))
            {
                StateComplete = true;
                return;
            }
            
            HandleMovement(context);
            HandleGravity(context);
            
            var currentVelocity = context.RigidBody.velocity;
            if (context.CollisionData.TouchingCeiling)
            {
                currentVelocity.y = 0;
            }
            
            context.RigidBody.velocity = currentVelocity;
        }
    }
}