using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject pickupParent;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private bool canJump = true;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

    private void OnJump()
    {
        if (canJump) {
            Vector3 curVel = rb.velocity;
            rb.velocity = new Vector3(curVel.x, 10, curVel.z);
        }
    }

    private void OnCollisionEnter()
    {
        canJump = true;
    }

    private void OnCollisionExit()
    {
        canJump = false;
    }

    private void SetCountText() 
   {
       countText.text =  "Count: " + count;
       if (count >= pickupParent.transform.childCount)
       {
           winTextObject.SetActive(true);
       }
   }

   private void FixedUpdate() 
   {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
   }

   private void OnTriggerEnter(Collider other) 
   {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
   }
}
