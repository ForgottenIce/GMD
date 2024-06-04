using UnityEngine;

namespace Checkpoint
{
    public class CheckpointInstance : MonoBehaviour
    {
        private CheckpointManager _checkpointManager;
        private Animator _animator;
        private AudioSource _audioSource;

        private void Start()
        {
            _checkpointManager = GetComponentInParent<CheckpointManager>();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _checkpointManager.SetCurrentCheckpoint(this);
            }
        }
        
        public Animator GetAnimator() => _animator;
        public AudioSource GetAudioSource() => _audioSource;
    }
}