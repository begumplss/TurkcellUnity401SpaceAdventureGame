using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickJumpingButton : MonoBehaviour , IPointerDownHandler , IPointerUpHandler
{
    [HideInInspector]//değişken public olsada inspectorda gizliyor
    public bool clickonbutton;
    public void OnPointerDown(PointerEventData eventData){
       
        clickonbutton=true;


    }

    public void OnPointerUp(PointerEventData eventData){
          clickonbutton=false;
    }
}
