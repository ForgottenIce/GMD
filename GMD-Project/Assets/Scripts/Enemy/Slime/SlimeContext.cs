using Scriptable_Objects.Audio;
using UnityEngine;

namespace Enemy.Slime
{
    public class SlimeContext
    {
        public SlimeStats SlimeStats { get; }
        public Rigidbody2D RigidBody { get; }
        public Animator Animator { get; }
        public AudioSource AudioSource { get; }
        public AudioClips AudioClips { get; }
        public Collider2D VisionRadius { get; }
        public Collider2D PatrolArea { get; }
        public Rigidbody2D PlayerRigidBody { get; }
        
        public bool PatrolOnNextStateChange { get; set; }
        public SlimeContext(SlimeStats slimeStats, Rigidbody2D rigidBody, Animator animator, AudioSource audioSource,
            AudioClips audioClips, Collider2D visionRadius, Collider2D patrolArea, Rigidbody2D playerRigidBody)
        {
            SlimeStats = slimeStats;
            RigidBody = rigidBody;
            Animator = animator;
            AudioSource = audioSource;
            AudioClips = audioClips;
            VisionRadius = visionRadius;
            PatrolArea = patrolArea;
            PlayerRigidBody = playerRigidBody;
        }
    }
}