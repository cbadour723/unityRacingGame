using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float speedMultiplier = 1f; // Multiplier for adjusting the car speed
    public float moveSpeed = 5f; // Base movement speed of the car
    public float turnSpeed = 100f; // Turning speed of the car
    public float acceleration = 2f; // Acceleration rate of the car
    public float braking = 2f; // Braking rate of the car
    public float maxSpeed = 5f; // Maximum speed of the car
    private float currentSpeed = 0f; // Current speed of the car
    public Rigidbody rb; // Reference to the car's Rigidbody component
    private bool isBoosting = false; // Flag to track if the car is currently boosting
    private float boostDuration = 3f; // Duration of the speed boost in seconds
    private float boostTimer = 0f; // Timer for tracking the duration of the boost

    void Start()
    {
        // Get the Rigidbody component attached to the car GameObject
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the space bar is pressed and the car is not currently boosting
        if (Input.GetKeyDown(KeyCode.Space) && !isBoosting)
        {
            // Start the boost
            isBoosting = true;
            boostTimer = boostDuration;
        }
    }
    public void SetMaxSpeedMultiplier(float maxspeed)
    {
        maxSpeed = maxspeed;
    }
    void FixedUpdate()
    {
        // Check if the car is grounded
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);

        // If the car is in the air, apply air resistance
        if (!isGrounded)
        {
            currentSpeed -= braking * Time.fixedDeltaTime;
            // Ensure the car doesn't go into reverse
            currentSpeed = Mathf.Max(currentSpeed, 0);
        }
        // Update boost timer if the car is currently boosting
        if (isBoosting)
        {
            boostTimer -= Time.fixedDeltaTime;

            // Check if the boost duration has ended
            if (boostTimer <= 0)
            {
                isBoosting = false; // End the boost
            }
        }
        // Get input from the horizontal axis (left/right arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");
        // Get input from the vertical axis (up/down arrow keys)
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction based on the input and the car's transform
        Vector3 movement = transform.forward * currentSpeed * Time.fixedDeltaTime;
        // Apply the movement to the car's Rigidbody
        rb.MovePosition(rb.position + movement);

        // Calculate the rotation amount based on the input and the turning speed
        float rotation = horizontalInput * turnSpeed * Time.fixedDeltaTime;
        // Create a rotation vector around the y-axis (up direction)
        Quaternion turnRotation = Quaternion.Euler(0f, rotation, 0f);
        // Apply the rotation to the car's Rigidbody
        rb.MoveRotation(rb.rotation * turnRotation);

        rb.MovePosition(rb.position + movement * speedMultiplier);

        // Accelerate the car
        if (verticalInput > 0)
        {
            // Apply regular acceleration or boost acceleration if currently boosting
            float currentAcceleration = isBoosting ? acceleration * 2f : acceleration;
            currentSpeed += currentAcceleration * Time.fixedDeltaTime;
            // Limit the speed to the maximum speed
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        }
        // Apply braking to decelerate the car
        else if (verticalInput < 0 && currentSpeed > 0)
        {
            currentSpeed -= braking * Time.fixedDeltaTime;
            // Ensure the car doesn't go into reverse
            currentSpeed = Mathf.Max(currentSpeed, 0);
        }
    }
}
