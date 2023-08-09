using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // This Script Handles Player Follow

    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // follow player with a offset
        Vector3 desiredPosition = target.position + offset;

        // smooth the follow speed
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
    // Script Made by Shubh Malhotra
}