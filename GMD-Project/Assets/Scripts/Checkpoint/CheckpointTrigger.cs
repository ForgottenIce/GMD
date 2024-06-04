using UnityEngine;

namespace Checkpoint
{
    public class CheckpointTrigger : MonoBehaviour
    {
        [SerializeField] private CheckpointManager checkpointManager;
        
        private Animator _animator;
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _animator.Play("checkpoint_collected");
            }
        }
    }
}