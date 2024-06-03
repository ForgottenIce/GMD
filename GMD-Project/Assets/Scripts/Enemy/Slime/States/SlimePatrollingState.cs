using System;
using UnityEngine;

namespace Enemy.Slime.States
{
    public class SlimePatrollingState : SlimeState
    {
        private int _moveDirection = 1;
        private float _patrolStartTime;

        protected override void OnEnterState(SlimeContext context)
        {
            context.Animator.Play("slime_walk");
            FaceMovementDirection(context);
            _patrolStartTime = Time.time;
        }

        public override void FixedUpdate(SlimeContext context)
        {
            var isInPatrolArea = context.PatrolArea.OverlapPoint(context.RigidBody.position);
            if (ShouldChargePlayer(context) || (_patrolStartTime + context.SlimeStats.patrolDuration < Time.time && isInPatrolArea))
            {
                context.PatrolOnNextStateChange = false;
                StateComplete = true;
                return;
            }
            
            if (!isInPatrolArea)
            {
                _moveDirection = context.PatrolArea.bounds.center.x > context.RigidBody.position.x ? 1 : -1;
                FaceMovementDirection(context);
            }
            
            var currentVelocity = context.RigidBody.velocity;
            if (IsCollidingWithWall(context))
            {
                currentVelocity.y = context.SlimeStats.moveSpeed;
            }
            else
            {
                currentVelocity.x = _moveDirection * context.SlimeStats.moveSpeed;
            }
            
            context.RigidBody.velocity = currentVelocity;
            
        }
        
        private void FaceMovementDirection(SlimeContext context)
        {
            var localScale = context.RigidBody.transform.localScale;
            localScale.x = Math.Abs(localScale.x) * _moveDirection;
            context.RigidBody.transform.localScale = localScale;
        }
        
        private bool IsCollidingWithWall(SlimeContext context)
        {
            // Quick and dirty way to check if the slime is colliding with a wall, not my proudest piece of code
            var origin = context.RigidBody.position + new Vector2(0, -1.2f);
            return Physics2D.BoxCast(origin, new Vector2(0.1f, 1.3f), 0, Vector2.right * _moveDirection, 1.2f, 1);
        }
    }
}