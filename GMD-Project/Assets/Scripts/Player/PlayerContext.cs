using UnityEngine;

namespace Player
{
    public class PlayerContext
    {
        public PlayerStats PlayerStats { get; }
        public PlayerInput PlayerInput { get; }
        public Rigidbody2D RigidBody { get; }
        public Animator Animator { get; }
        
        public PlayerCollisionData CollisionData { get; set; } // Must only be set by PlayerMovementStateMachine
        
        // Shared variables
        public bool JumpPadUsed { get; set; }
        public bool CoyoteTimeActive { get; set; }
        public bool DashAvailable { get; set; }
        
        public PlayerContext(PlayerStats playerStats, PlayerInput playerInput, Rigidbody2D rigidBody, Animator animator)
        {
            PlayerStats = playerStats;
            PlayerInput = playerInput;
            RigidBody = rigidBody;
            Animator = animator;
        }
    }
}