using UnityEngine;

//PF
//Script handles enemy and pickup collisions, as well as health system and talisman functions

public class Collisions : MonoBehaviour
{
    public float maxEnergy = 100f, currentEnergy, enemyDmgVal = 15f, energyPickupVal = 10f;

    public AudioSource source;
    public AudioClip damaged, energyPU;

    private HealthBar healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        currentEnergy = maxEnergy; 

        source = GetComponent<AudioSource>();

        healthBar = FindFirstObjectByType<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        if(col.CompareTag("EnergyPU"))
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

        if (col.CompareTag("Enemy"))
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
