using StateMachine;
using UnityEngine;

namespace Enemy.Slime.States
{
    public class SlimeState : State<SlimeContext>
    {
        // This method is used to determine if the slime should charge the player
        // The slime prioritizes getting back to the patrol area over charging the player
        public static bool ShouldChargePlayer(SlimeContext context)
        {
            var currentPosition = context.RigidBody.position;
            var playerPosition = context.PlayerRigidBody.position;
            
            var distanceToPatrolArea = Vector2.Distance(currentPosition, context.PatrolArea.bounds.ClosestPoint(currentPosition));
            var playerDistanceToPatrolArea = Vector2.Distance(playerPosition, context.PatrolArea.bounds.ClosestPoint(playerPosition));
            
            var isPlayerInVisionRadius = context.VisionRadius.OverlapPoint(playerPosition);
            var isInPatrolArea = context.PatrolArea.OverlapPoint(currentPosition);

            return isPlayerInVisionRadius && (isInPatrolArea || playerDistanceToPatrolArea < distanceToPatrolArea);
        }
    }
}