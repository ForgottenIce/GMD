using System;
using TMPro;
using UnityEngine;

namespace Sign
{
    public class SignUIHandler : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshPro;
        public void ShowText(string text)
        {
            gameObject.SetActive(true);
            _textMeshPro.text = text;
        }

        private void OnEnable()
        {
            if (_textMeshPro == null)
            {
                _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
            }
        }

        public void HideText()
        {
            gameObject.SetActive(false);
        }
    }
}
