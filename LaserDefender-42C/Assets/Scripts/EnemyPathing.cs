using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = new List<Transform>();// a collection to store different waypoints
    //set in Unity. These waypoints will represent the path that the enemy needs to move along.

    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0; // used to keep track of the current point we are working with. The index is the 
    //position of the current waypoint.

    // Start is called before the first frame update
    void Start()
    {
        /* Setting the current enemy to be located on the first waypoint in the list.
         * Different properties are fetched from their components. Our list is made up of just Transform components
         * so each item is a trasform component, thus, waypoints[waypointIndex] will be translated to transform.
         * That way, we just call the position property from this current transform. 
         */
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        //checking if there are any more points in the list
        if (waypointIndex < waypoints.Count) // if(waypointIndex <= waypoints.Count - 1)
        {
            float movementThisFrame = moveSpeed * Time.deltaTime; // making the enemy movement frame independent
            Vector3 targetPosition = waypoints[waypointIndex].position;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++; // waypointIndex = waypointIndex + 1;
            }
        }
        else // there are no more waypoints left in the list (all of them have been traversed)
        {
            /* The keyword gameObject refers to the object which has this current script attached to it. Therefore,
             * we will be destroying the current enemy which has reached the end of the path.
             */
            Destroy(gameObject);
        }
    }
}
