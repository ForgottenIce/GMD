using UnityEngine;
using UnityEngine.SceneManagement;

namespace Checkpoint
{
    public class CheckpointManager : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        
        private CheckpointInstance _currentCheckpoint;

        public void SetCurrentCheckpoint(CheckpointInstance checkpoint)
        {
            if (checkpoint == _currentCheckpoint) return;
            
            if (_currentCheckpoint != null) _currentCheckpoint.GetAnimator().Play("checkpoint_uncollected");
            _currentCheckpoint = checkpoint;
            _currentCheckpoint.GetAnimator().Play("checkpoint_collected");
            _currentCheckpoint.GetAudioSource().Play();
        }
        
        public void RestartAtCurrentCheckpoint()
        {
            if (_currentCheckpoint == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                player.SetActive(true);
                player.transform.position = _currentCheckpoint.transform.position;
            }
        }
    }
}