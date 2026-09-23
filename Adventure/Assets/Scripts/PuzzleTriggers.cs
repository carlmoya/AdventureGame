using UnityEngine;
using static Unity.VisualScripting.Member;

public class PuzzleTriggers : MonoBehaviour
{
    public AudioSource source;
    public AudioClip pu;

    
    //PF This script is for managing puzzle logic.
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
            source.clip = pu;
            source.Play();

            Destroy(col.gameObject);
        }
    }
}
