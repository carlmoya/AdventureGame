using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Script written by Carl Moya

public class HealthBar : MonoBehaviour
{
    // Fields

    [Header("Assignment Settings")] [Space(15)]
    public Image healthBarFill;
    public SpriteRenderer playerSpriteRenderer;

    [Header("Health Change Animation Settings")] [Space(15)]
    public float healthChangeAnimationDuration = 0.5f;

    private Collisions collisions;

    // Methods

    private void Start()
    {
        collisions = FindFirstObjectByType<Collisions>();
    }

    public void AnimateHealth(Color startColor)
    {
        StopAllCoroutines();

        StartCoroutine(HealthChangeAnimation(startColor));
    }

    // Coroutines

    private IEnumerator HealthChangeAnimation(Color startColor)
    {
        // Get start health bar fill amount from health bar fill amount
        float startFillAmount = healthBarFill.fillAmount;

        // Get target health bar fill amount from current energy
        float targetFillAmount = CurrentEnergyPercentage();

        // Track & increase the elapsed time of the animation
        for (float elapsedTime = 0f; elapsedTime < healthChangeAnimationDuration; elapsedTime += Time.deltaTime)
        {
            // Normalize elapsed time
            float time = elapsedTime / healthChangeAnimationDuration;

            // Interpolate player sprite renderer color over time
            Color currentColor = Color.Lerp(startColor, Color.white, time);

            // Interpolate health bar fill amount over time
            float currentFillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, time);

            // Apply current color to player sprite renderer
            playerSpriteRenderer.color = currentColor;

            // Apply current fill amount to health bar fill
            healthBarFill.fillAmount = currentFillAmount;

            // Wait for next frame
            yield return null;
        }

        // Ensure target player sprite renderer color
        playerSpriteRenderer.color = Color.white;

        // Ensure target health bar fill amount
        healthBarFill.fillAmount = targetFillAmount;
    }

    // Return Methods

    public float CurrentEnergyPercentage()
    {
        return collisions.currentEnergy / 100f;
    }
}
