using UnityEngine;

namespace Camera
{
    public class CameraZoneDetection : MonoBehaviour
    {
        [SerializeField]
        private CameraController cameraController;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("CameraZone") && cameraController != null)
            {
                cameraController.SetCurrentTarget(other.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("CameraZone") && cameraController != null)
            {
                cameraController.SetCurrentTarget(transform);
            }
        }
    }
}
