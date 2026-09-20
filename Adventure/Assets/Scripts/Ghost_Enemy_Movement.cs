using UnityEngine;

//PF script handles enemy movement and behaviors

public class Ghost_Enemy_Movement : MonoBehaviour
{
    public Transform playerLocation;
    public float speed, distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 3.0f;
        distance = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float proximity = Vector2.Distance(transform.position, playerLocation.position);

        if (proximity < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerLocation.position, speed * Time.deltaTime);
        }
    }
}
