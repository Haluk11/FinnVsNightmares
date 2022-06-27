using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Hit;
    static AudioSource audioSrc;
    void Start()
    {
        Hit = Resources.Load<AudioClip> ("Hitt");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playkek ()
    {
        audioSrc.PlayOneShot(Hit);
    }

    
}
