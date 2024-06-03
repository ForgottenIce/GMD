using UnityEngine;

namespace Enemy.Slime
{
    [CreateAssetMenu]
    public class SlimeStats : ScriptableObject
    {
        [Header("Movement")]
        public float moveSpeed;
        public float jumpPower;
        
        [Header("Charge")]
        public float chargeSpeed;
        public float chargeDuration;
        public float chargeYOffset;
        
        [Header("Patrol & Idle")]
        public float idleDuration;
        public float patrolDuration;
    }
}