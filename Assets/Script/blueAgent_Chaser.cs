using UnityEngine;

public class BlueAgentController : MonoBehaviour
{
    public Transform redAgent; // Assign red object
    public float speed = 5.0f;

    void Update()
    {
        // Move towards the red agent
        transform.position = Vector3.MoveTowards(transform.position, redAgent.position, speed * Time.deltaTime);
    }
}
