using UnityEngine;

//PF
//Script handles enemy and pickup collisions, as well as health system and talisman functions

public class Collisions : MonoBehaviour
{
    public float maxEnergy = 100f, currentEnergy, enemyDmgVal = 15f, energyPickupVal = 10f;

    public AudioSource source;
    public AudioClip damaged, energyPU;

    private HealthBar healthBar; // Line added by Carl Moya

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        currentEnergy = maxEnergy; 

        source = GetComponent<AudioSource>();

        healthBar = FindFirstObjectByType<HealthBar>(); // Line added by Carl Moya
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

            healthBar.AnimateHealth(Color.green); // Line added by Carl Moya

            Destroy(col.gameObject);

            if (currentEnergy > maxEnergy)
            {
                currentEnergy = maxEnergy;
            }
        }

        if (col.CompareTag("Enemy"))
        {
            source.clip = damaged;
            source.Play();

            currentEnergy -= enemyDmgVal;

            healthBar.AnimateHealth(Color.red); // Line added by Carl Moya
        }

    }

}
