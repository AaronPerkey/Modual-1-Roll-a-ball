using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Variable to keep track of collected "PickUp" objects.
    private int count;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    // Speed at which the player moves.
    public float speed = 0;

    // UI text component to display count of "PickUp" objects collected.
    public TextMeshProUGUI countText;

    // UI object to display winning text.
    public GameObject winTextObject;

    public GameObject youDiedObject;
    // Coroutine reference to control the display duration of the "You Died" message.
    public GameObject backgroundColor;
    private Coroutine youDiedCoroutine;

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();

        // Initialize count to zero.
        count = 0;

        // Update the count display.
        SetCountText();

        // Initially set the win text to be inactive.
        backgroundColor.SetActive(false);
        winTextObject.SetActive(false);
        youDiedObject.SetActive(false);
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }


    void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);

            // Increment the count of "PickUp" objects collected.
            count = count + 1;

            // Update the count display.
            SetCountText();
        }

        
        if (other.gameObject.CompareTag("Death"))
        {
            // Player dies
            transform.position = new Vector3(0f, 0.5f, 0f);
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Activate the "You Died" message.
            youDiedObject.SetActive(true);

            backgroundColor.SetActive(true);

            // Start the coroutine to hide the "You Died" message after a duration.
            if (youDiedCoroutine != null)
            {
                StopCoroutine(youDiedCoroutine);
            }
            youDiedCoroutine = StartCoroutine(HideYouDiedMessageAfterDuration(3f)); // Change 3f to the desired duration.
        }
    }

    // Coroutine to hide the "You Died" message after a specified duration.
    IEnumerator HideYouDiedMessageAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Deactivate the "You Died" message after the duration.
        youDiedObject.SetActive(false);
        backgroundColor.SetActive(false);
        
    }

    // Function to update the displayed count of "PickUp" objects collected.
    void SetCountText()
    {
        // Update the count text with the current count.
        countText.text = "Count: " + count.ToString();

        // Check if the count has reached or exceeded the win condition.
        if (count >= 12)
        {
            // Display the win text.
            winTextObject.SetActive(true);
        }
    }
}