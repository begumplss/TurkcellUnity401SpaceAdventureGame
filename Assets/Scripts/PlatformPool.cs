using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefab = default;

    [SerializeField]
    GameObject deadlyplatformPrefab = default;

    [SerializeField]
    GameObject playerPrefab = default;

    private List<GameObject> platforms = new List<GameObject>();
    private Vector2 platformPosition;
    private bool playerCreated = false; // Player'ın zaten oluşturulup oluşturulmadığını kontrol etmek için

    [SerializeField]
    float platformDistance = default;

    void Start()
    {
        if (platformPrefab == null)
        {
            Debug.LogError("Platform Prefab is not assigned in the Inspector!");
            return;
        }
        GenerateInitialPlatforms();
    }

    void Update()
    {
        // En son platform, kamera görünümünün altına düştüğünde yeni platform oluştur
        if (platforms.Count > 0 && platforms[platforms.Count - 1].transform.position.y < Camera.main.transform.position.y + DisplayCalculate.instance.Height)
        {
            BuildPlatform();
        }
    }

    void GenerateInitialPlatforms()
    {
        platformPosition = new Vector2(0, 0);

        // Oyun başladığında sadece bir kere player oluştur
        if (!playerCreated)
        {
            Vector2 playerPosition = new Vector2(0, 0.5f); // Oyun başlarken player bir platformun üstünde
            Instantiate(playerPrefab, playerPosition, Quaternion.identity);
            playerCreated = true; // Player oluşturuldu, bir daha oluşturma
        }

        // İlk platformu oluştur
        GameObject firstPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
        platforms.Add(firstPlatform);
        NextPlatformPosition();
        firstPlatform.GetComponent<Platform>().Hareket = false; // İlk platform hareketsiz, true hareketli

        // İlk 8 platformu oluştur
        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Hareket = true; // Platform hareket etmeye başlar
            if(i%2==0){
                platform.GetComponent<Gold>().GoldOn();
            }
            NextPlatformPosition(); // Yeni pozisyon hesapla
        }
        
        // İlk deadly platformu oluştur
        GameObject deadlyPlatform = Instantiate(deadlyplatformPrefab, platformPosition, Quaternion.identity);
        platforms.Add(deadlyPlatform);
        deadlyPlatform.GetComponent<DeadlyPlatform>().Hareket = true;
        NextPlatformPosition();
    }

    void BuildPlatform() //Yerleştir
    {
        for (int i = 0; i < 5; i++)
        {
            //Yeni bir platform oluştur
            GameObject platform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Hareket = true; // Yeni platform hareket etmeye başlar
            // Gold eklemek için rastgele olasılık
        float randomGold = Random.Range(0.0f, 1.0f); // 0 ile 1 arasında rastgele sayı
        if (randomGold > 0.5f) // %50 olasılıkla gold ekle
        {
            Gold goldComponent = platform.GetComponent<Gold>();
            if (goldComponent != null)
            {
                goldComponent.GoldOn(); // Gold'u aç
            }
        }
        else
        {
            Gold goldComponent = platform.GetComponent<Gold>();
            if (goldComponent != null)
            {
                goldComponent.GoldOff(); // Gold'u kapalı tut
            }
        }

            
            NextPlatformPosition(); // Sonraki pozisyonu ayarla

             
        
            // Platformu yenileyerek oluştur
            //GameObject temp = platforms[i + 5];
            //platforms[i + 5] = platforms[i];
            //platforms[i] = temp;
            //platforms[i + 5].transform.position = platformPosition; // Yeni pozisyon
            //NextPlatformPosition(); // Sonraki pozisyonu ayarla
        
        }
    }

    void NextPlatformPosition()
    {
        platformPosition.y += platformDistance;
        float random = Random.Range(0.0f, 1.0f);
        if (random < 0.5f)
        {
            platformPosition.x = DisplayCalculate.instance.Width / 2;
        }
        else
        {
            platformPosition.x = -DisplayCalculate.instance.Width / 2;
        }
          //SiraliPozisyon();

    }
        // void KarmaPozisyon(){
        //     float random = Random.Range(0.0f, 1.0f);
        // if (random < 0.5f)
        // {
        //     platformPosition.x = DisplayCalculate.instance.Width / 2;
        // }
        // else
        // {
        //     platformPosition.x = -DisplayCalculate.instance.Width / 2;
        // }

        // }
        // bool yon=true;

        // void SiraliPozisyon(){
        //     if(yon){
        //          platformPosition.x = DisplayCalculate.instance.Width / 2;
        //          yon=false;

        //     }else{
        //         platformPosition.x = -DisplayCalculate.instance.Width / 2;
        //         yon=true;
        //     }

        // }
    
}
