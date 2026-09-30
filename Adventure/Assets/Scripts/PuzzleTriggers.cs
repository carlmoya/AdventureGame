using UnityEngine;
using static Unity.VisualScripting.Member;

//PHOEBE: i 
public class PuzzleTriggers : MonoBehaviour
{
    public AudioSource source;
    public AudioClip talismanPU;
    //int riddle;
    
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
        if (col.CompareTag("Talisman"))
        {
            source.clip = talismanPU;
            source.Play();

            PuzzleInteractable.currentRiddle = 8;

            Destroy(col.gameObject);
        }
    }

}
