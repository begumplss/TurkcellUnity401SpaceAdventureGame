using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenKeep : MonoBehaviour
{
    
    void Update()
    {
        if(transform.position.x<-DisplayCalculate.instance.Width){
            Vector2 temp=transform.position;
            temp.x= -DisplayCalculate.instance.Width;
            transform.position=temp;
        }
        
        if(transform.position.x>DisplayCalculate.instance.Width){
            Vector2 temp=transform.position;
            temp.x= DisplayCalculate.instance.Width;
            transform.position=temp;
        }
    }
}
