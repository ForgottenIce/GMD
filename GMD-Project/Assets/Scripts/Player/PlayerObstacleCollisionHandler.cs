using UnityEngine;

namespace Player
{
    public class PlayerObstacleCollisionHandler : MonoBehaviour
    {
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Player collided with obstacle");
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Player collided with obstacle");
            }
        }
    }
}