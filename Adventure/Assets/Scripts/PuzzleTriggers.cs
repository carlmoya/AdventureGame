using UnityEngine;
using static Unity.VisualScripting.Member;

//PHOEBE: puzzle trigger for win condition
public class PuzzleTriggers : MonoBehaviour
{
    public AudioSource source; 
    public AudioClip talismanPU;
    
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Talisman")) //Collect talisman, destroy sprite, play sound
        {
            source.clip = talismanPU;
            source.Play();

            GameObject.FindFirstObjectByType<GameManager>().Win(); // Line added by Carl Moya

            Destroy(col.gameObject);
        }
    }

}
