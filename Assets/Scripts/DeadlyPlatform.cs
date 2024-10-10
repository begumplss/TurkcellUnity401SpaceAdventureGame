using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DeadlyPlatform : MonoBehaviour
{
    
    BoxCollider2D boxCollider2D;
    
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
        boxCollider2D = GetComponent<BoxCollider2D>();
        randomHiz = Random.Range(0.5f, 1.0f);

        float objectWidth = boxCollider2D.bounds.size.x / 2;

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

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag== "Feet"){
            FindAnyObjectByType<GameControl>().GameOver();
        }
        
    }
}
