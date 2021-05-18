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

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator[currentPathIndex].pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator[currentPathIndex].path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator[currentPathIndex].path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                if (transform.position == pathCreator[currentPathIndex].path.GetPoint(1))
                {
                    currentPathIndex++;
                    distanceTravelled = 0;
                }
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator[currentPathIndex].path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}