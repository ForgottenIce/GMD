using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Vector2 playerCameraOffset;
    [SerializeField]
    private float transitionSpeed;
    
    private float _elapsedTransitionTime;
    
    private Transform _currentTarget;
    private Transform _previousTarget;
    
    public void SetCurrentTarget(Transform target)
    {
        _previousTarget = _currentTarget;
        _currentTarget = target;
        _elapsedTransitionTime = 0;
    }

    private void Start()
    {
        _currentTarget = playerTransform;
        _previousTarget = playerTransform;
    }

    private void LateUpdate()
    {
        var currentTargetOffset = _currentTarget == playerTransform ? playerCameraOffset : Vector2.zero;
        // Smooth camera transition
        if (_elapsedTransitionTime < transitionSpeed)
        {
            _elapsedTransitionTime += Time.deltaTime;
            var previousTargetOffset = _previousTarget == playerTransform ? playerCameraOffset : Vector2.zero;
            var lerp = Vector2.Lerp((Vector2)_previousTarget.position + previousTargetOffset, 
                (Vector2)_currentTarget.position + currentTargetOffset, 
                Mathf.Clamp01(_elapsedTransitionTime / transitionSpeed));
            transform.position = new Vector3(lerp.x, lerp.y, transform.position.z);
            return;
        }
        transform.position = new Vector3(
            _currentTarget.position.x + currentTargetOffset.x,
            _currentTarget.position.y + currentTargetOffset.y,
            transform.position.z);
    }
}
