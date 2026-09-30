using UnityEngine;
using System.Linq;

// Script written by Carl Moya

public class AiMovement : BaseMovement
{
    // Fields

    [Header("\nTarget Settings")] [Space(15)]
    public string[] likes = new string[0];
    public string[] dislikes = new string[0];

    [Header("Search Settings")] [Space(15)]
    public float targetSearchRadius = 10f;

    // Return Methods

    protected override Vector2 TargetPosition()
    {
        foreach (string dislike in dislikes)
        {
            if (FoundGameObjectWithTag(dislike, out GameObject dislikedGameObject))
            {
                return PositionAwayFromPosition(dislikedGameObject.transform.position, targetSearchRadius);
            }
        }

        foreach (string like in likes)
        {
            if (FoundGameObjectWithTag(like, out GameObject likedGameObject))
            {
                return likedGameObject.transform.position;
            }
        }

        return rb.position;
    }

    protected bool FoundGameObjectWithTag(string tag, out GameObject gameObjectWithTag)
    {
        // Return false if tag is not defined
        if (string.IsNullOrEmpty(tag)) { return (gameObjectWithTag = null) != null; }

        // Get all colliders within search radius
        Collider2D closestColliderWithTag = Physics2D.OverlapCircleAll(transform.position, targetSearchRadius)

            // Check for tag
            .Where(otherCollider => otherCollider.CompareTag(tag) == true)

            // Sort by distance
            .OrderBy(otherCollider => Vector2.Distance(otherCollider.transform.position, transform.position))

            // Set closest collider with tag
            .FirstOrDefault();

        // Set game object with tag and return true if not null
        return (gameObjectWithTag = closestColliderWithTag?.gameObject) != null;
    }

    protected Vector2 PositionAwayFromPosition(Vector2 position, float distanceFromPosition)
    {
        Vector2 positionAwayFromPosition = (Vector2)transform.position + (DirectionAwayFromPosition(position) * distanceFromPosition);

        return positionAwayFromPosition;
    }

    protected Vector2 DirectionAwayFromPosition(Vector2 position)
    {
        Vector2 directionAwayFromPosition = ((Vector2)transform.position - position).normalized;

        return directionAwayFromPosition;
    }
}
