using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTaker : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag== "Feet"){
            //Debug.Log("Player Geldi");
            GetComponentInParent<Gold>().GoldOff();
            FindObjectOfType<Score>().Goldget();
        }

    }
}
