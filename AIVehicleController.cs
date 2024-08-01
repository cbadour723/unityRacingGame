using UnityEngine;

public class AIVehicleController : MonoBehaviour
{
    public WaypointManager waypointManager;
    public float moveSpeed = 5f;
    public float maxSpeed = 10f; // Maximum speed of the vehicle
    public float acceleration = 2f; // Acceleration rate of the vehicle
    public float turnSpeed = 100f;

    public bool resetSpeedAtWaypoint = true; // Option to reset speed when reaching a new waypoint
    public float waypointResetSpeed = 0f; // Speed to reset to when reaching a new waypoint

    private int currentWaypointIndex = 0;
    private float currentSpeed = 0f; // Current speed of the vehicle

    void Update()
    {
        if (waypointManager.waypoints.Count == 0)
        {
            Debug.LogWarning("No waypoints found.");
            return;
        }

        Vector3 targetDirection = waypointManager.waypoints[currentWaypointIndex].position - transform.position;
        targetDirection.y = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        // Accelerate the vehicle if it hasn't reached the maximum speed yet
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed); // Clamp the speed to the maximum speed
        }

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypointManager.waypoints[currentWaypointIndex].position) < 10f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypointManager.waypoints.Count;

            if (resetSpeedAtWaypoint)
            {
                currentSpeed = waypointResetSpeed; // Reset speed when reaching a new waypoint
            }
        }
    }
}

