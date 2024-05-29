using TMPro;
using UnityEngine;

namespace Sign
{
    public class SignUIHandler : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshPro;
        
        private void Start()
        {
            _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        }
        public void ShowText(string text)
        {
            gameObject.SetActive(true);
            _textMeshPro.text = text;
        }
        
        public void HideText()
        {
            gameObject.SetActive(false);
        }
    }
}
