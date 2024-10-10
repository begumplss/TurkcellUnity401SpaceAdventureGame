using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public static MusicControl instance;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        Singelton(); // Singleton deseni başlatılıyor
        audioSource = GetComponent<AudioSource>();
    }

    // Singleton oluşturma
    void Singelton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance); // Müzik kontrol nesnesini yok etmiyoruz, tüm sahnelerde kalıyor
        }
    }

    // Müzik açma/kapama fonksiyonu
    public void MusicOn(bool play)
    {
        if (play)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
