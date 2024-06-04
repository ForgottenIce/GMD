using System.Collections;
using Player;
using UnityEngine;

namespace Orb
{
    public class OrbCooldownHandler : MonoBehaviour
    {
        [SerializeField] private float orbCooldown;
        
        public void ApplyCooldown(GameObject orbInstance)
        {
            StartCoroutine(TemporarilyDisableOrb(orbInstance));
        }
        
        private IEnumerator TemporarilyDisableOrb(GameObject orbInstance)
        {
            orbInstance.SetActive(false);
            yield return new WaitForSeconds(orbCooldown);
            orbInstance.SetActive(true);
        }
    }
}