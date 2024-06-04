using Checkpoint;
using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    public class CheckpointRespawnMenu : MonoBehaviour
    {
        [SerializeField] private CheckpointManager checkpointManager;
        
        private GameObject _checkpointRespawnUi;
        private Button _respawnButton;
        private Button _exitButton;

        private void Start()
        {
            _checkpointRespawnUi = transform.GetChild(0).gameObject;
            
            _respawnButton = _checkpointRespawnUi.transform.GetChild(0).GetComponent<Button>();
            _exitButton = _checkpointRespawnUi.transform.GetChild(1).GetComponent<Button>();
        }
        
        public void ShowMenu()
        {
            _checkpointRespawnUi.SetActive(true);
            _respawnButton.Select();
        }
        
        public void RespawnAtCurrentCheckpoint()
        {
            _checkpointRespawnUi.SetActive(false);
            checkpointManager.RestartAtCurrentCheckpoint();
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
