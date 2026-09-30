using UnityEngine;

//PHOEBE: Make ghosts move toward player

public class Ghost_Enemy_Movement : MonoBehaviour
{
    public Transform playerLocation; 
    public float speed, distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 3.0f; // Value for ghost move speed
        distance = 4.0f; // Value for ghost chase distance
    }

    // Update is called once per frame
    void Update()
    {
        float proximity = Vector2.Distance(transform.position, playerLocation.position); //Calculate distance from player

        if (proximity < distance) // If player is closer to ghost than chase distance value, moe ghost toward player position
        {
            transform.position = Vector2.MoveTowards(transform.position, playerLocation.position, speed * Time.deltaTime);
        }
    }
}
