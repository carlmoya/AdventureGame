using UnityEngine;

//PHOEBE: Script handles enemy and pickup collisions, as well as health system and talisman functions

public class Collisions : MonoBehaviour
{
    public float maxEnergy = 100f, currentEnergy, enemyDmgVal = 15f, energyPickupVal = 10f;

    public AudioSource source;
    public AudioClip damaged, energyPU;

    private HealthBar healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        currentEnergy = maxEnergy; // Set player's energy to the max on start 

        source = GetComponent<AudioSource>();

        healthBar = FindFirstObjectByType<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        if(col.CompareTag("EnergyPU")) // If player collides with energy refill pickup, play sound, increment energy, destroy pickup, limit energy to a max value
        {
            source.clip = energyPU;
            source.Play();

            currentEnergy += 10f;

            healthBar.AnimateHealth(Color.green);

            Destroy(col.gameObject);

            if (currentEnergy > maxEnergy)
            {
                currentEnergy = maxEnergy;
            }
        }

        if (col.CompareTag("Enemy")) // If player collides with enemy, play sound, decrement energy
        {
            if (PuzzleInteractable.currentRiddle >= 8)
            {
                Destroy(col.gameObject);

                if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 1)
                {
                    FindFirstObjectByType<GameManager>().Win();
                }

                return;
            }

            source.clip = damaged;
            source.Play();

            currentEnergy -= enemyDmgVal;

            healthBar.AnimateHealth(Color.red);
        }

    }

}
