using UnityEngine;
using System.Linq;

public class AiMovement : MovementBase
{
    // Fields

    public string[] likes;
    public string[] dislikes;

    public float searchRadius;

    // Return Methods

    protected override Vector2 TargetPosition() // Defined by base class
    {
        foreach (string dislike in dislikes)
        {
            if (FoundGameObjectWithTag(dislike, out GameObject dislikedGameObject))
            {
                return new Ray2D(transform.position, dislikedGameObject.transform.position - transform.position).GetPoint(-searchRadius);
            }
        }

        foreach (string like in likes)
        {
            if (FoundGameObjectWithTag(like, out GameObject likedGameObject))
            {
                return likedGameObject.transform.position;
            }
        }

        return rb.position; // BUG: Not causing ai to stand still
    }

    protected bool FoundGameObjectWithTag(string tag, out GameObject gameObjectWithTag)
    {
        gameObjectWithTag = Physics2D.OverlapCircleAll(transform.position, searchRadius)
            .Where(otherCollider => otherCollider.CompareTag(tag) == true)
            .OrderBy(otherCollider => Vector2.Distance(otherCollider.transform.position, transform.position))
            .FirstOrDefault().gameObject;

        return gameObjectWithTag != null;
    }
}
