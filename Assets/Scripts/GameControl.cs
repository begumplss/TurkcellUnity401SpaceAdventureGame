using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject joystick;
    
    public GameObject jumpingButton;
    public GameObject Tabela;
    
    public GameObject MenuButton;
    public GameObject Slider;



    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        UIOpen();

        

    }

    void ApplyDifficultySettings()
    {
        // Zorluk seviyesini kontrol et ve buna göre oyun ayarlarını uygula
        if (SelectionsMemory.EasyLevelDetected() == 1)
        {
            Debug.Log("Easy modunda oynanıyor.");
            // Easy zorluk seviyesi için oyun ayarlarını yap
        }
        else if (SelectionsMemory.NormalLevelDetected() == 1)
        {
            Debug.Log("Normal modunda oynanıyor.");
            // Normal zorluk seviyesi için oyun ayarlarını yap
        }
        else if (SelectionsMemory.HardLevelDetected() == 1)
        {
            Debug.Log("Hard modunda oynanıyor.");
            // Hard zorluk seviyesi için oyun ayarlarını yap
        }
    }

    public void GameOver(){
        FindObjectOfType<SoundsControl>().GameOverSound();
        GameOverPanel.SetActive(true);
        FindObjectOfType<Score>().GameOver();
        FindObjectOfType<PlayerMovement>().GameOver();
        UIClose();
    }

    public void BackHome(){
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain(){
        SceneManager.LoadScene("Game");
    }

    void UIOpen(){
        joystick.SetActive(true);
        jumpingButton.SetActive(true);
        Tabela.SetActive(true);
        MenuButton.SetActive(true);
        Slider.SetActive(true);
        
    }

     void UIClose(){
        joystick.SetActive(false);
        jumpingButton.SetActive(false);
        Tabela.SetActive(false);
        MenuButton.SetActive(false);
        Slider.SetActive(false);
        
    }
}
