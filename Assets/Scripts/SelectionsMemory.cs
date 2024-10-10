using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public static class SelectionsMemory
{  //PLAYERPREFBS
    public static string easy="easy";
    public static string normal="normal";
    public static string hard="hard";

    
    public static string easyScore="easyScore";
    public static string normalScore="normalScore";
    public static string hardScore="hardScore";

    
    public static string easyGold="easyGold";
    public static string normalGold="normalGold";
    public static string hardGold="hardGold";

     public static string musicOn="musicOn";

    public static void EasySelected (int easy){
        PlayerPrefs.SetInt(SelectionsMemory.easy, easy);

    }

   public static int EasyLevelDetected() 
{
    return PlayerPrefs.GetInt(SelectionsMemory.easy, 1); // Eğer değer yoksa varsayılan olarak 1 (easy) ver
}


    public static void NormalSelected (int normal){
         PlayerPrefs.SetInt(SelectionsMemory.normal, normal);
    }

    public static int NormalLevelDetected(){ //oku
            return PlayerPrefs.GetInt(SelectionsMemory.normal);
    }


    public static void HardSelected (int hard){
         PlayerPrefs.SetInt(SelectionsMemory.hard, hard);
    }

    public static int HardLevelDetected(){ //oku
            return PlayerPrefs.GetInt(SelectionsMemory.hard);
    }


    
    public static void EasyScoreSelected (int easyScore){
        PlayerPrefs.SetInt(SelectionsMemory.easyScore, easyScore);

    }

    public static int EasyLevelScoreDetected(){ //oku
            return PlayerPrefs.GetInt(SelectionsMemory.easyScore);
    }

    public static void NormalScoreSelected (int normalScore){
         PlayerPrefs.SetInt(SelectionsMemory.normalScore, normalScore);
    }

    public static int NormalScoreLevelDetected(){ //oku
            return PlayerPrefs.GetInt(SelectionsMemory.normalScore);
    }


    public static void HardScoreSelected (int hardScore){
         PlayerPrefs.SetInt(SelectionsMemory.hardScore, hardScore);
    }

    public static int HardScoreLevelDetected(){ //oku
            return PlayerPrefs.GetInt(SelectionsMemory.hardScore);
    }
    
    public static void EasyGoldSelected (int easyGold){
        PlayerPrefs.SetInt(SelectionsMemory.easyGold, easyGold);

    }

    public static int EasyLevelGoldDetected(){ //oku
            return PlayerPrefs.GetInt(SelectionsMemory.easyGold);
    }

    public static void NormalGoldSelected (int normalGold){
         PlayerPrefs.SetInt(SelectionsMemory.normalGold, normalGold);
    }

    public static int NormalLevelGoldDetected(){ //oku
            return PlayerPrefs.GetInt(SelectionsMemory.normalGold);
    }


    public static void HardGoldSelected (int hardGold){
         PlayerPrefs.SetInt(SelectionsMemory.hardGold, hardGold);
    }

    public static int HardLevelGoldDetected(){ //oku
            return PlayerPrefs.GetInt(SelectionsMemory.hardGold);
    }

     public static void musicOnSelected (int musicOn){
         PlayerPrefs.SetInt(SelectionsMemory.musicOn, musicOn);
    }

    public static int musicOnDetected(){ //oku
            return PlayerPrefs.GetInt(SelectionsMemory.musicOn);
    }
   public static bool Kayitvarmi()
{
    // Her bir anahtar için HasKey kontrolü yap
    if (PlayerPrefs.HasKey(SelectionsMemory.easy) ||
        PlayerPrefs.HasKey(SelectionsMemory.normal) ||
        PlayerPrefs.HasKey(SelectionsMemory.hard))
    {
        return true; // En az bir anahtar varsa true döndür
    }
    else
    {
        return false; // Hiç anahtar yoksa false döndür
    }
}

public static bool MusicOnKayitvarmi()
{
    // Her bir anahtar için HasKey kontrolü yap
    if (PlayerPrefs.HasKey(SelectionsMemory.musicOn)){
        return true; 
    }
    else
    {
        return false; // Hiç anahtar yoksa false döndür
    }
}



}