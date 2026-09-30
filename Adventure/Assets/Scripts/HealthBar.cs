using UnityEngine;
using UnityEngine.UI;

// Script written by Carl Moya

public class HealthBar : MonoBehaviour
{
    // Fields

    public Image healthBarFill;

    private Collisions collisions;

    // Methods

    private void Start()
    {
        collisions = FindFirstObjectByType<Collisions>();
    }

    private void Update()
    {
        
    }
}
