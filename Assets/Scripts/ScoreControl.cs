using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
     public Text easyScore, easyGold, normalGold, normalScore, hardScore, hardGold;
    
    void Start()
    {
        // Skorları güncelle
        easyScore.text = "Score: " + SelectionsMemory.EasyLevelScoreDetected();
        easyGold.text = "X" + SelectionsMemory.EasyLevelGoldDetected();

        normalScore.text = "Score: " + SelectionsMemory.NormalScoreLevelDetected();
        normalGold.text = "X" + SelectionsMemory.NormalLevelGoldDetected();

        hardScore.text = "Score: " + SelectionsMemory.HardScoreLevelDetected();
        hardGold.text = "X" + SelectionsMemory.HardLevelGoldDetected();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
