using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Vector2 cameraOffset;

    private Transform _currentTarget;
    
    public void SetCurrentTarget(Transform target)
    {
        _currentTarget = target;
    }

    private void Start()
    {
        _currentTarget = playerTransform;
    }

    private void LateUpdate()
    {
        transform.position = _currentTarget == playerTransform 
            ? new Vector3(_currentTarget.position.x + cameraOffset.x, _currentTarget.position.y + cameraOffset.y, transform.position.z)
            : new Vector3(_currentTarget.position.x, _currentTarget.position.y, transform.position.z);
    }
}
