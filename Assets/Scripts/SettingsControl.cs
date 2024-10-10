using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{
    public Button easyButton, normalButton, hardButton;
    // Start is called before the first frame update
    void Start()
{
    easyButton.onClick.AddListener(() => SecenekSecildi("easy"));
    normalButton.onClick.AddListener(() => SecenekSecildi("normal"));
    hardButton.onClick.AddListener(() => SecenekSecildi("hard"));

    // Butonların başlangıç durumunu ayarla
    if (SelectionsMemory.EasyLevelDetected() == 1)
    {
        easyButton.interactable = false;
        normalButton.interactable = true;
        hardButton.interactable = true;
    }
    else if (SelectionsMemory.NormalLevelDetected() == 1)
    {
        easyButton.interactable = true;
        normalButton.interactable = false;
        hardButton.interactable = true;
    }
    else if (SelectionsMemory.HardLevelDetected() == 1)
    {
        easyButton.interactable = true;
        normalButton.interactable = true;
        hardButton.interactable = false;
    }
    else
    {
        // Varsayılan olarak easy'i seç
        SelectionsMemory.EasySelected(1);
        easyButton.interactable = false;
        normalButton.interactable = true;
        hardButton.interactable = true;
    }
}

      public void SecenekSecildi(string level)
{
     switch (level)
        {
            case "easy":
                SelectionsMemory.EasySelected(1);
                SelectionsMemory.NormalSelected(0);
                SelectionsMemory.HardSelected(0);
                // Oyun sahnesine geçiş yap
                SceneManager.LoadScene("Game"); 
                break;

            case "normal":
                SelectionsMemory.EasySelected(0);
                SelectionsMemory.NormalSelected(1);
                SelectionsMemory.HardSelected(0);
                // Oyun sahnesine geçiş yap
                SceneManager.LoadScene("Game"); 
                break;

            case "hard":
                SelectionsMemory.EasySelected(0);
                SelectionsMemory.NormalSelected(0);
                SelectionsMemory.HardSelected(1);
                // Oyun sahnesine geçiş yap
                SceneManager.LoadScene("Game"); 
                break;

            default:
                break;
        }
}

public void ResetSelections()
{
    PlayerPrefs.DeleteKey(SelectionsMemory.easy);
    PlayerPrefs.DeleteKey(SelectionsMemory.normal);
    PlayerPrefs.DeleteKey(SelectionsMemory.hard);

    // Butonların başlangıç durumuna dönmesini sağla
    easyButton.interactable = false;
    normalButton.interactable = true;
    hardButton.interactable = true;

    SelectionsMemory.EasySelected(1); // Varsayılan olarak Easy seçili
}


    public void MainMenu(){
       ResetSelections();
    SceneManager.LoadScene("Menu");

    }
}
