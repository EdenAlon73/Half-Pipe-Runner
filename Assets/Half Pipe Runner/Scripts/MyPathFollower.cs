using System;
using UnityEngine;
using PathCreation;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class MyPathFollower : MonoBehaviour
    {
        [SerializeField] private int currentPathIndex;
        public PathCreator[] pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;
        [SerializeField] private bool finishedPath;

        void Start()
        {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator[currentPathIndex].pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            StartPath();
            GoToNextPath();
            print(finishedPath);
        }
        
        void OnPathChanged() 
        {
            distanceTravelled = pathCreator[currentPathIndex].path.GetClosestDistanceAlongPath(transform.position);
        }

        private void StartPath()
        {
            if (pathCreator != null && !finishedPath)
            {
                //finishedPath = false;
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator[currentPathIndex].path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator[currentPathIndex].path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                
                if (transform.position == pathCreator[currentPathIndex].path.GetPoint(1))
                {
                    finishedPath = true;
                }
                
            }
        }
        private void GoToNextPath()
        {
            if (finishedPath)
            {
                currentPathIndex++;
                distanceTravelled = 0;
                finishedPath = false;
            }
        }
    }
    
    
}