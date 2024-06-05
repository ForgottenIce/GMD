using Checkpoint;
using Input;
using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    public class CheckpointRespawnMenu : MonoBehaviour
    {
        [SerializeField] private CheckpointManager checkpointManager;
        [SerializeField] private InputManager inputManager;

        private GameObject _checkpointRespawnUi;
        private Button _respawnButton;

        private AudioSource _audioSource;

        private void Start()
        {
            _checkpointRespawnUi = transform.GetChild(0).gameObject;

            _respawnButton = _checkpointRespawnUi.transform.GetChild(0).GetComponent<Button>();

            _audioSource = GetComponent<AudioSource>();
        }

        public void ShowMenu()
        {
            _checkpointRespawnUi.SetActive(true);
            inputManager.PauseButtonDisabled = true;
            _audioSource.Play();
            _respawnButton.Select();
        }

        public void RespawnAtCurrentCheckpoint()
        {
            _checkpointRespawnUi.SetActive(false);
            inputManager.PauseButtonDisabled = false;
            checkpointManager.RestartAtCurrentCheckpoint();
        }
    }
}
