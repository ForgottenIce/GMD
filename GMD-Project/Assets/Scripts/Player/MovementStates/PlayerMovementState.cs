using System;
using JumpPad;
using StateMachine;
using UnityEngine;

namespace Player.MovementStates
{
    public abstract class PlayerMovementState : State<PlayerContext>
    {
        protected static void HandleMovement(PlayerContext context)
        {
            var currentVelocity = context.RigidBody.velocity;
            var playerStats = context.PlayerStats;
            var playerInput = context.PlayerInput;
            var transform = context.RigidBody.transform;
            
            switch (context.PlayerInput.MoveDirection)
            {
                case -1:
                    transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    if (currentVelocity.x > 0) currentVelocity.x = 0;
                    currentVelocity.x += playerInput.MoveDirection * playerStats.acceleration;
                    if (context.CollisionData.TouchingLeftWall) currentVelocity.x = 0;
                    break;
                case 1:
                    transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    if (currentVelocity.x < 0) currentVelocity.x = 0;
                    currentVelocity.x += context.PlayerInput.MoveDirection * playerStats.acceleration;
                    if (context.CollisionData.TouchingRightWall) currentVelocity.x = 0;
                    break;
                case 0:
                    currentVelocity.x = 0;
                    break;
            }
            if (currentVelocity.x > playerStats.maxSpeed) currentVelocity.x = playerStats.maxSpeed;
            if (currentVelocity.x < -playerStats.maxSpeed) currentVelocity.x = -playerStats.maxSpeed;

            context.RigidBody.velocity = currentVelocity;
        }
        
        protected static void HandleJump(PlayerContext context)
        {
            var currentVelocity = context.RigidBody.velocity;
            currentVelocity.y = context.PlayerStats.jumpPower;
            context.RigidBody.velocity = currentVelocity;
        }

        protected static void HandleGravity(PlayerContext context)
        {
            var currentVelocity = context.RigidBody.velocity;
            var maxFallSpeed = context.PlayerStats.maxFallSpeed;
            
            float newFallSpeed = currentVelocity.y - context.PlayerStats.gravity;
            if (newFallSpeed < -maxFallSpeed) newFallSpeed = -maxFallSpeed;
            currentVelocity.y = newFallSpeed;
            
            context.RigidBody.velocity = currentVelocity;

        }
        
        // States can opt out of this method by overriding it if they don't need to interact with jump pads
        public virtual void InteractWithJumpPad(PlayerContext context, float jumpPower)
        {
            var currentVelocity = context.RigidBody.velocity;
            currentVelocity.y = jumpPower;
            context.RigidBody.velocity = currentVelocity;
            
            context.JumpPadUsed = true;
        }
        
    }
}