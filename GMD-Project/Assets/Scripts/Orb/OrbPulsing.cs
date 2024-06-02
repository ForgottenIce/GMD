using UnityEngine;

namespace Orb
{
    public class OrbPulsing : MonoBehaviour
    {
        [SerializeField] private float pulseSpeed;
        [SerializeField] private float pulseAmount;
        
        private bool _pulsingUp = true;
        
        private void Update()
        {
            if (_pulsingUp)
            {
                transform.localScale += Vector3.one * (pulseSpeed * Time.deltaTime);
                if (transform.localScale.x >= 1 + pulseAmount)
                {
                    _pulsingUp = false;
                }
            }
            else
            {
                transform.localScale -= Vector3.one * (pulseSpeed * Time.deltaTime);
                if (transform.localScale.x <= 1)
                {
                    _pulsingUp = true;
                }
            }
        }
    }
}