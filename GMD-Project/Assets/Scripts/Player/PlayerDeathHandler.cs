using Menus;
using UnityEngine;

namespace Player
{
    public class PlayerDeathHandler : MonoBehaviour
    {
        [SerializeField] CheckpointRespawnMenu checkpointRespawnMenu;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                gameObject.SetActive(false);
                checkpointRespawnMenu.ShowMenu();
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                gameObject.SetActive(false);
                checkpointRespawnMenu.ShowMenu();
            }
        }
    }
}