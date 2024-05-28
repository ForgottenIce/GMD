using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] private DialogLines _dialogLines;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }
    
    
}
