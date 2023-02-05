using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(audioSource);
        if(!audioSource.isPlaying){
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
