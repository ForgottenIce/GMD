using System.Collections;
using Player;
using UnityEngine;

namespace Orb
{
    // This script is attached to the player and handles the player's interaction with orbs
    // The script should arguably be in the Player namespace
    public class PlayerOrbHandler : MonoBehaviour
    {
        [SerializeField] private float orbCooldown;
        
        private PlayerMovementStateMachine _playerMovementStateMachine;

        private void Start()
        {
            _playerMovementStateMachine = GetComponent<PlayerMovementStateMachine>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("JumpOrb"))
            {
                _playerMovementStateMachine.JumpOrbCollected();
                StartCoroutine(TemporarilyDisableOrb(other.gameObject));
            }
            
            if (other.CompareTag("DashOrb"))
            {
                _playerMovementStateMachine.DashOrbCollected();
                StartCoroutine(TemporarilyDisableOrb(other.gameObject));
            }
        }
        
        private IEnumerator TemporarilyDisableOrb(GameObject orb)
        {
            orb.SetActive(false);
            yield return new WaitForSeconds(orbCooldown);
            orb.SetActive(true);
        }
    }
}