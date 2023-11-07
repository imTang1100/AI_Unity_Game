using UnityEngine;
using UnityEngine.AI; // For the NavMesh

public class RedAgentController_ori : MonoBehaviour
{
    public Transform destination; // Assign yellow object 
    public Transform blueAgent; // Assign blue object 
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destination.position; // Set the destination to the yellow object
    }

    void Update()
    {
        // Optionally, update the destination if it moves
        agent.destination = destination.position;

        // Check if the red agent has reached the destination
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

    private void GameOver(string message)
    {
        Debug.Log(message);
        // Here handle the game over logic, like stopping the game, showing a message
    }
}

