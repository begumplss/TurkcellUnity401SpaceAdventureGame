using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsControl : MonoBehaviour
{
    public AudioClip jumping;
    public AudioClip gold;
    public AudioClip gameOver;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        
    }
    public void JumpingSound(){
        audioSource.clip=jumping;
        audioSource.Play();


    }
    public void GoldSound(){
        audioSource.clip=gold;
        audioSource.Play();


    }
    public void GameOverSound(){
        audioSource.clip=gameOver;
        audioSource.Play();


    }


}
