using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBehaviour : MonoBehaviour
{

    public GameObject playerObject;

    public AudioSource punchAudio;
    public AudioSource kickAudio;
    public AudioSource hitAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject != null)
        {
            if (playerObject.GetComponent<CharacterMovement>().punch)
            {
                punchAudio.Play();
            } 
        }
    }
    public void OnHit()
    {
        hitAudio.Play();
    }
}
