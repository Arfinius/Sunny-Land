using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Vector3 offset; // Moving the camera by vector.

    public Transform target;

    public float smoothSpeed = 1f; 

    float upBorder = 0.4035942f; // The upper limit of the camera on the map.

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothedPosition;

        if (smoothedPosition.y >= upBorder)
        {
            smoothedPosition = new Vector3(smoothedPosition.x, upBorder, -10);
        }
    }
		
}