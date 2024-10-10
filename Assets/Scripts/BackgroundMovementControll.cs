using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovementControll : MonoBehaviour
{
    float arkaPlanKonum;
    float mesafe = 10.24f; // orta mesafe 


    // Start is called before the first frame update
    void Start()
    {
        arkaPlanKonum = transform.position.y;
        FindObjectOfType<Planets>().planetAdd(arkaPlanKonum);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(arkaPlanKonum+mesafe<Camera.main.transform.position.y){
            ArkaPlanYerlestirme();
        }
    }

    void ArkaPlanYerlestirme(){
        arkaPlanKonum += ( mesafe * 2);
        FindObjectOfType<Planets>().planetAdd(arkaPlanKonum);
        Vector2 yeniPozisyon = new Vector2(0,arkaPlanKonum);
        transform.position = yeniPozisyon;

    }
}
