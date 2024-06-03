using UnityEngine;

namespace Enemy.Slime
{
    public class SlimeContext
    {
        public SlimeStats SlimeStats { get; }
        public Rigidbody2D RigidBody { get; }
        public Collider2D Collider { get; }
        public Animator Animator { get; }
        public Collider2D VisionRadius { get; }
        public Collider2D PatrolArea { get; }
        public Rigidbody2D PlayerRigidBody { get; }
        
        public bool PatrolOnNextStateChange { get; set; }
        public SlimeContext(SlimeStats slimeStats, Rigidbody2D rigidBody, Collider2D collider, Animator animator, Collider2D visionRadius, Collider2D patrolArea, Rigidbody2D playerRigidBody)
        {
            SlimeStats = slimeStats;
            RigidBody = rigidBody;
            Collider = collider;
            Animator = animator;
            VisionRadius = visionRadius;
            PatrolArea = patrolArea;
            PlayerRigidBody = playerRigidBody;
        }
    }
}