using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField]
    GameObject gold = default;

    public void GoldOn(){
        gold.SetActive(true);
    }

    public void GoldOff(){
        gold.SetActive(false);
    }

}
