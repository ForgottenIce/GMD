using Input;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menus
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;

        private bool _isPaused;
        private GameObject _pauseUi;
        private Button _resumeButton;
        private Button _restartButton;
        private Button _exitButton;
        
        private int _selectedButtonIndex;

        private void Start()
        {
            _pauseUi = transform.GetChild(0).gameObject;
            
            _resumeButton = _pauseUi.transform.GetChild(0).GetComponent<Button>();
            _restartButton = _pauseUi.transform.GetChild(1).GetComponent<Button>();
            _exitButton = _pauseUi.transform.GetChild(2).GetComponent<Button>();
        }
        
        private void Update()
        {
            if (inputManager.PausePressed && !_isPaused)
            {
                PauseGame();
                _resumeButton.Select();
            }
            else if (inputManager.PausePressed && _isPaused)
            {
                ResumeGame();
            }
        }
        
        public void PauseGame()
        {
            _isPaused = true;
            Time.timeScale = 0f;
            _pauseUi.SetActive(true);
        }
        
        public void ResumeGame()
        {
            _isPaused = false;
            Time.timeScale = 1f;
            _pauseUi.SetActive(false);
        }
        
        public void RestartGame()
        {
            ResumeGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void ExitGame()
        {
            Application.Quit();
        }

        // private void HandleMenuNavigation()
        // {
        //     if (_isPaused && inputManager.MenuUpPressed)
        //     {
        //         _selectedButtonIndex--;
        //         if (_selectedButtonIndex < 0)
        //         {
        //             _selectedButtonIndex = 2;
        //         }
        //         switch (_selectedButtonIndex)
        //         {
        //             case 0:
        //                 _resumeButton.Select();
        //                 break;
        //             case 1:
        //                 _restartButton.Select();
        //                 break;
        //             case 2:
        //                 _exitButton.Select();
        //                 break;
        //         }
        //     }
        //     else if (_isPaused && inputManager.MenuDownPressed)
        //     {
        //         _selectedButtonIndex++;
        //         if (_selectedButtonIndex > 2)
        //         {
        //             _selectedButtonIndex = 0;
        //         }
        //         switch (_selectedButtonIndex)
        //         {
        //             case 0:
        //                 _resumeButton.Select();
        //                 break;
        //             case 1:
        //                 _restartButton.Select();
        //                 break;
        //             case 2:
        //                 _exitButton.Select();
        //                 break;
        //         }
        //     }
        // }
        //
        // private void HandleMenuClick()
        // {
        //     switch (_selectedButtonIndex)
        //     {
        //         case 0:
        //             ResumeGame();
        //             break;
        //         case 1:
        //             RestartGame();
        //             break;
        //         case 2:
        //             ExitGame();
        //             break;
        //     }
        // }
    }
}
