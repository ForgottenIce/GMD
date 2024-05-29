using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sign
{
    public class SignInteractionHandler : MonoBehaviour
    {
        [SerializeField] private DialogLines dialogLines;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private SignUIHandler signUIHandler;
        private bool _isPlayerInRange;
        private bool _isPlayerReadingSign;
        private int _currentDialogLine;
        private GameObject _inputHint;

        private void Start()
        {
            _inputHint = transform.Find("InputHint").gameObject;
        }
        private void Update()
        {
            if (_isPlayerInRange && playerInput.InteractPressed)
            {
                if (!_isPlayerReadingSign)
                {
                    _isPlayerReadingSign = true;
                    signUIHandler.ShowText(dialogLines.dialogLines[_currentDialogLine]);
                }
                else
                {
                    _currentDialogLine++;
                    if (_currentDialogLine < dialogLines.DialogCount)
                    {
                        signUIHandler.ShowText(dialogLines.dialogLines[_currentDialogLine]);
                    }
                    else
                    {
                        HideAndReset();
                    }
                }

            }

            if (!_isPlayerInRange && _isPlayerReadingSign)
            {
                HideAndReset();
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _isPlayerInRange = true;
                _inputHint.SetActive(true);
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _isPlayerInRange = false;
                _inputHint.SetActive(false);
            }
        }
        
        private void HideAndReset()
        {
            signUIHandler.HideText();
            _isPlayerReadingSign = false;
            _currentDialogLine = 0;
        }
    }
}
