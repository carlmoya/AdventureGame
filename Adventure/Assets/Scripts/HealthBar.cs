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

    private void FixedUpdate()
    {
        UpdateFillAmount();
    }

    private void UpdateFillAmount()
    {
        if (collisions == null) return;

        healthBarFill.fillAmount = Mathf.MoveTowards(healthBarFill.fillAmount, (collisions.currentEnergy / 100f), 0.005f);
    }

    // Return Methods

    public float InterpolatedEnergyPercentage()
    {
        float interpolatedEnergyPercentage = Mathf.MoveTowards(healthBarFill.fillAmount, CurrentEnergyPercentage(), 0.005f);

        return interpolatedEnergyPercentage;
    }

    public float CurrentEnergyPercentage()
    {
        float currentEnergyPercentage = collisions.currentEnergy / 100f;

        return currentEnergyPercentage;
    }
}
