using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    [Header("Movement Config")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    
    [Header("Waypoints")]
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private int currentWaypointIndex;
    
    private bool moveForward = true;
    

    private void Start()
    {
        transform.position = waypoints[0].position;
        transform.rotation = waypoints[0].rotation;
        moveForward = true;
    }
    private void Update()
    {
        MoveToCurrentIndexPoint();
        LerpRotation();
    }

    private void MoveToCurrentIndexPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position,
            moveSpeed * Time.deltaTime);
        
        if (transform.position == waypoints[currentWaypointIndex].position)
        {
            if (moveForward)
            {
                if (currentWaypointIndex + 1 < waypoints.Length)
                {
                    currentWaypointIndex++;
                }
            }
            
        }
    }

    private void LerpRotation()
    {
        var currentRotation = transform.eulerAngles;
        var waypointRotation = waypoints[currentWaypointIndex].transform.eulerAngles;
        currentRotation.y = Mathf.Lerp(currentRotation.y, waypointRotation.y,
            Time.deltaTime * rotationSpeed);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentRotation.y, transform.eulerAngles.z);
    }
}
