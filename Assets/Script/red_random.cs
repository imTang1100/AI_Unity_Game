using UnityEngine;
using UnityEngine.AI; // For the NavMesh

public class RedAgentController : MonoBehaviour
{
    public Transform destination; // Assign yellow object 
    public Transform blueAgent; // Assign blue object 
    private NavMeshAgent agent;

    public Transform[] waypoints; // Assign waypoints here in the inspector
    private int currentWaypointIndex;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentWaypointIndex = 0;
        SetNextDestination();
    }

    void Update()
    {
        // If close enough to the current waypoint, set the next waypoint as the destination
        if (!agent.pathPending && agent.remainingDistance < agent.stoppingDistance)
        {
            SetNextDestination();
        }

        // Check if the red agent has reached the final destination
        if (Vector3.Distance(destination.position, transform.position) < 1f)
        {
            // Reached the yellow object
            GameOver("Red reached the destination");
        }

        // Check if the blue agent has caught the red agent
        if (Vector3.Distance(blueAgent.position, transform.position) < 1f)
        {
            // Blue caught red
            GameOver("Blue caught red");
        }
    }

    void SetNextDestination()
    {
        if (waypoints.Length == 0) return;

        // Set the next waypoint from the array as the destination
        agent.destination = waypoints[currentWaypointIndex].position;

        // Increase the waypoint index, loop back to 0 if it goes out of bounds
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

        // If the current waypoint is the last one, set the destination to the yellow object
        if (currentWaypointIndex == 0)
        {
            agent.destination = destination.position;
        }
    }

    private void GameOver(string message)
    {
        Debug.Log(message);
        // Here handle the game over logic, like stopping the game, showing a message, etc.
        agent.enabled = false; // This stops the NavMeshAgent
    }
}

