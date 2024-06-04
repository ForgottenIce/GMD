using System;
using Menus;
using UnityEngine;

namespace MoneyBag
{
    public class CompleteLevel : MonoBehaviour
    {
        [SerializeField] private AudioSource backgroundMusicAudioSource;
        [SerializeField] private LevelCompleteMenu levelCompleteMenu;
        
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                backgroundMusicAudioSource.Stop();
                _audioSource.Play();
                levelCompleteMenu.ShowCompletionScreen();
            }
        }
    }
}
