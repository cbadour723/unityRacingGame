using UnityEngine;
using System.Collections.Generic;

public class WaypointManager : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();

    // Automatically populate the list of waypoints with child transforms
    void Awake()
    {
        waypoints.Clear();
        foreach (Transform child in transform)
        {
            waypoints.Add(child);
        }
    }

    // Draw gizmos to visualize waypoints in the Unity Editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach (Transform waypoint in waypoints)
        {
            Gizmos.DrawSphere(waypoint.position, 0.5f);
        }

        Gizmos.color = Color.blue;
        for (int i = 0; i < waypoints.Count - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
        }

        // Connect the last waypoint to the first one to form a closed loop track
        if (waypoints.Count > 1)
        {
            Gizmos.DrawLine(waypoints[waypoints.Count - 1].position, waypoints[0].position);
        }
    }
}

