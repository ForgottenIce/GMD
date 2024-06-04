using System.Collections;
using UnityEngine;

namespace Unlockable
{
    public class Unlocker : MonoBehaviour
    {
        [SerializeField] private GameObject unlockableGameObject;
        private IUnlockable _unlockable;
        
        private AudioSource _audioSource;
        private SpriteRenderer _spriteRenderer;

        private bool _isCollected;

        private void Start()
        {
            _unlockable = unlockableGameObject.GetComponent<IUnlockable>();
            _audioSource = GetComponent<AudioSource>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !_isCollected)
            {
                _unlockable?.UnlockAction();
                _audioSource.Play();
                _spriteRenderer.color = Color.clear;
                _isCollected = true;
                StartCoroutine(DelayedDestroy());
            }
        }
        
        // Hacky way to play the audio clip before destroying the game object
        private IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }
    }
}
