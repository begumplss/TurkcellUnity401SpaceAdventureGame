using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;
    
    float randomHiz; // Platformun rastgele hızı
    bool hareket;    // Platform hareket ediyor mu?

    float min, max;  // Platformun hareket edebileceği minimum ve maksimum değerler

    public bool Hareket {
        get { return hareket; }
        set { hareket = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        //randomHiz = Random.Range(0.5f, 1.0f);
         if(SelectionsMemory.EasyLevelDetected()==1){
             randomHiz = Random.Range(0.5f, 1.0f);
         }

        if(SelectionsMemory.NormalLevelDetected()==1){
             randomHiz = Random.Range(0.8f, 1.5f);
       
        }
        
        if(SelectionsMemory.HardLevelDetected()==1){
             randomHiz = Random.Range(1.5f, 2.5f);
        
        }

        float objectWidth = polygonCollider2D.bounds.size.x / 2;

        // Sağ veya sol tarafa göre min ve max değerleri ayarlayın
        if (transform.position.x > 0) // Ekranın sağ tarafında
        {
            min = objectWidth;
            max = DisplayCalculate.instance.Width - objectWidth;
        }
        else // Ekranın sol tarafında
        {
            min = -DisplayCalculate.instance.Width + objectWidth;
            max = -objectWidth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hareket)
        {
            // PingPong ile sola ve sağa hareket ettirin
            float pingPongX = Mathf.PingPong(Time.time * randomHiz, max - min) + min;
            transform.position = new Vector2(pingPongX, transform.position.y);
        }
    }
void OnTriggerEnter2D(Collider2D collider)
{
    // Eğer çarpışan obje Feet tag'ine sahipse
    if(collider.gameObject.tag == "Feet")
    {
        //Debug.Log("Karakter platforma geldi.");
        // Platformun hareketine bağlı olarak karakteri platforma bağla
        GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMovement>().ResetJumping();

    }
}


}
