using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Config")]
    [SerializeField] private Transform followTarget;
    [SerializeField] private float smoothSpeed = 10f;
    [SerializeField] private Vector3 offset;
    
    private void LateUpdate()
    {
        Vector3 desiredPosition = followTarget.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(followTarget);
    }
}
