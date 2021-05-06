using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovingForward : MonoBehaviour
{
    [SerializeField] private float forwardMoveSpeed = 1f;
    [SerializeField] private float zValue = 1f;
    
    void Update()
    {
        transform.position = transform.position + new Vector3(0, 0, zValue* forwardMoveSpeed * Time.deltaTime);
        
    }
}
