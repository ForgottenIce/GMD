using Player;
using UnityEngine;

namespace Orb
{
    public class OrbInstance : MonoBehaviour
    {
        private OrbCooldownHandler _orbCooldownHandler;
        
        private void Start()
        {
            _orbCooldownHandler = GetComponentInParent<OrbCooldownHandler>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerMovementStateMachine = other.GetComponent<PlayerMovementStateMachine>();
            
            if (playerMovementStateMachine != null)
            {
                if (gameObject.CompareTag("JumpOrb"))
                {
                    playerMovementStateMachine.JumpOrbCollected();
                }
                if (gameObject.CompareTag("DashOrb"))
                {
                    playerMovementStateMachine.DashOrbCollected();
                }
                
                _orbCooldownHandler.ApplyCooldown(gameObject);
            }
        }
    }
}