using UnityEngine;
using System.Linq;

// Script written by Carl Moya

public class AiMovement : BaseMovement
{
    // Fields

    public string[] likes = new string[0];
    public string[] dislikes = new string[0];

    public float searchRadius = 10f;

    // Return Methods

    protected override Vector2 TargetPosition() // Defined by base class
    {
        // Go thru dislikes
        foreach (string dislike in dislikes)
        {
            // If a disliked game object is found
            if (FoundGameObjectWithTag(dislike, out GameObject dislikedGameObject))
            {
                // Get the direction away from the disliked game object
                Vector2 awayDirection = ((Vector2)transform.position - (Vector2)dislikedGameObject.transform.position).normalized;

                // Return a position away from the disliked game object
                return (Vector2)transform.position + (awayDirection * searchRadius);
            }
        }

        // Go thru likes
        foreach (string like in likes)
        {
            // If a liked game object is found
            if (FoundGameObjectWithTag(like, out GameObject likedGameObject))
            {
                // Return the position of the liked game object
                return likedGameObject.transform.position;
            }
        }

        return rb.position;
    }

    protected bool FoundGameObjectWithTag(string tag, out GameObject gameObjectWithTag)
    {
        if (string.IsNullOrEmpty(tag))
        {
            gameObjectWithTag = null;
            return false;
        }

        // Get all colliders within search radius
        Collider2D closestColliderWithTag = Physics2D.OverlapCircleAll(transform.position, searchRadius)

            // Check for tag
            .Where(otherCollider => otherCollider.CompareTag(tag) == true)

            // Sort by distance
            .OrderBy(otherCollider => Vector2.Distance(otherCollider.transform.position, transform.position))

            // Set closest collider with tag
            .FirstOrDefault();

        // Set game object with tag and return true if not null
        return (gameObjectWithTag = closestColliderWithTag?.gameObject) != null;
    }
}
