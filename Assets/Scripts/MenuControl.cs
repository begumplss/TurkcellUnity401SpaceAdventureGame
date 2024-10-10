using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    Sprite[] MusicIcons=default;

    [SerializeField]
    Button musicButton=default;

    bool musicOn=true;
    // Start is called before the first frame update
    void Start()
    {
        if(SelectionsMemory.Kayitvarmi()==false){
            SelectionsMemory.EasySelected(1);
        }
        if (SelectionsMemory.MusicOnKayitvarmi()==false){
            SelectionsMemory.musicOnSelected(1);
        }
        MusicSettingsCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene("Game");
 
    }

    public void HighScore(){
        SceneManager.LoadScene("Score");
    }

    public void Settings(){
        SceneManager.LoadScene("Settings");
    }

    public void Music(){
        if(SelectionsMemory.musicOnDetected()==1){
           SelectionsMemory.musicOnSelected(0);
           MusicControl.instance.MusicOn(false);
           musicButton.image.sprite=MusicIcons[0];

        }else{
            SelectionsMemory.musicOnSelected(1);
            MusicControl.instance.MusicOn(true);
            musicButton.image.sprite=MusicIcons[1];
        }
    }

    void MusicSettingsCheck(){
        if(SelectionsMemory.musicOnDetected() == 1){
            musicButton.image.sprite=MusicIcons[1];
            MusicControl.instance.MusicOn(true);
        } else{
            musicButton.image.sprite=MusicIcons[0];
            MusicControl.instance.MusicOn(false);
        }
    }
}
