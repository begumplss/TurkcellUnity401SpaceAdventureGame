using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class KameraHareket : MonoBehaviour
{
    float hiz;
    float hizlanma;
    float maxHiz ;

    bool hareket = true;


    // Start is called before the first frame update
    void Start()
    {
        if(SelectionsMemory.EasyLevelDetected()==1){
        hiz =0.3f;
        hizlanma=0.03f;
        maxHiz=1.5f; }

        if(SelectionsMemory.NormalLevelDetected()==1){
        hiz =0.5f;
        hizlanma=0.05f;
        maxHiz=2.0f;
        }
        
        if(SelectionsMemory.HardLevelDetected()==1){
        hiz =0.8f;
        hizlanma=0.08f;
        maxHiz=2.5f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(hareket){

        KameraHareketEttir();
        }

    }

    void KameraHareketEttir(){
        transform.position+=transform.up*hiz*Time.deltaTime;
        hiz += hizlanma*Time.deltaTime;
        
        if(hiz> maxHiz){
            hiz = maxHiz;
        }

    }
}
