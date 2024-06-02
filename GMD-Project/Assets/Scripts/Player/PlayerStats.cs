using UnityEngine;

namespace Player
{
    [CreateAssetMenu]
    public class PlayerStats : ScriptableObject
    {
        [Header("Speed")]
        public float maxSpeed;
        public float acceleration;
        
        [Header("Gravity")]
        public float gravity;
        public float maxFallSpeed;
        
        [Header("Jumping")]
        public float jumpPower;
        public float jumpReleaseMultiplier;
        public float coyoteTime;
        
        [Header("Dashing")]
        public float dashPower;
        public float dashDuration;
        public float dashCooldown;
    }
}