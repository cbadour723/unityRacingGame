using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform target; // Reference to the object the camera will follow
    public Vector3 offset; // Offset between the camera and the target

    void Update()
    {
        if (target != null)
        {
            // Set the position of the camera to be the same as the target plus the offset
            transform.position = target.position + offset;
        }
    }
}
