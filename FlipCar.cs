using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCar : MonoBehaviour
{
    public float groundRaycastDistance = 1.0f; // Distance for the ground raycast
    public float maxFlipAngle = 80.0f; // Maximum angle before flipping
    public float flipForce = 500.0f; // Force applied to flip the car

    void Update()
    {
        // Check if the car is rotated beyond the maxFlipAngle
        if (transform.eulerAngles.z > maxFlipAngle && transform.eulerAngles.z < 360.0f - maxFlipAngle)
        {
            // Check if the car is grounded
            if (IsGrounded())
            {
                // Flip the car back onto its wheels
                Flip();
            }
        }
    }

    bool IsGrounded()
    {
        // Cast a ray downwards to check if the car is grounded
        return Physics.Raycast(transform.position, -transform.up, groundRaycastDistance);
    }

    private void Flip()
    {
        // Apply a force to flip the car back onto its wheels
        GetComponent<Rigidbody>().AddForce(Vector3.up * flipForce, ForceMode.Impulse);
    }
}
