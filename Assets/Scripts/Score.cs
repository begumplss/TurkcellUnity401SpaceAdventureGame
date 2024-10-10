using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int HighScore;
    int gold;
    int maxGold;

    bool collectScore=true;

    [SerializeField]
    Text ScoreText=default;

     [SerializeField]
    Text GoldText =default;

    [SerializeField]
    Text GameOverScoreText=default;

     [SerializeField]
    Text GameOverGoldText =default;

    // Start is called before the first frame update
    void Start()
    {
        GoldText.text=" X "+gold;
    }

    // Update is called once per frame
    void Update()
    {
        if(collectScore){
        score=((int)Camera.main.transform.position.y);
        ScoreText.text="Score: "+score;
        
        }
       
    }

    public void Goldget(){
        FindObjectOfType<SoundsControl>().GoldSound();
        gold++;
        GoldText.text=" X "+gold;
    }

    public void GameOver(){
        if(SelectionsMemory.EasyLevelDetected()==1){
            HighScore= SelectionsMemory.EasyLevelDetected();
            maxGold=SelectionsMemory.EasyLevelGoldDetected();
            if(score> HighScore){
                SelectionsMemory.EasyScoreSelected(score);
            }
            if(gold>maxGold){
                SelectionsMemory.EasyGoldSelected(gold);
            }

        }

        if(SelectionsMemory.NormalLevelDetected()==1){
            HighScore= SelectionsMemory.NormalLevelDetected();
            maxGold=SelectionsMemory.NormalLevelGoldDetected();
            if(score> HighScore){
                SelectionsMemory.NormalScoreSelected(score);
            }
            if(gold>maxGold){
                SelectionsMemory.NormalGoldSelected(gold);
            }

        }

        if(SelectionsMemory.HardLevelDetected()==1){
            HighScore= SelectionsMemory.HardLevelDetected();
            maxGold=SelectionsMemory.HardLevelGoldDetected();
            if(score> HighScore){
                SelectionsMemory.HardScoreSelected(score);
            }
            if(gold>maxGold){
                SelectionsMemory.HardGoldSelected(gold);
            }

        }

        
        collectScore=false;
        GameOverScoreText.text="Score" + score;
        GameOverScoreText.text=" X " + gold;
        
    }
}
