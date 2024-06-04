using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menus
{
    public class LevelCompleteMenu : MonoBehaviour
    {
        
        private GameObject _levelCompleteUi;
        private Button _playAgainButton;
        private Button _exitButton;
        
        private void Start()
        {
            _levelCompleteUi = transform.GetChild(0).gameObject;
            
            _playAgainButton = _levelCompleteUi.transform.GetChild(1).GetComponent<Button>();
            _exitButton = _levelCompleteUi.transform.GetChild(2).GetComponent<Button>();
        }
        
        public void ShowCompletionScreen()
        {
            Time.timeScale = 0f;
            _levelCompleteUi.SetActive(true);
            _playAgainButton.Select();
        }
        
        public void PlayAgain()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}