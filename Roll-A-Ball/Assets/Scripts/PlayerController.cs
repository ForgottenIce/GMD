using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float maxSpeed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject pickupParent;
    private Rigidbody rb;
    private JumpCollider jumpCollider;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);

        jumpCollider = GetComponentInChildren<JumpCollider>();

    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnJump()
    {
        if (jumpCollider.canJump)
        {
            Vector3 curVel = rb.velocity;
            rb.velocity = new Vector3(curVel.x, jumpHeight, curVel.z);
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count;
        if (count >= pickupParent.transform.childCount)
        {
            winTextObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
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
