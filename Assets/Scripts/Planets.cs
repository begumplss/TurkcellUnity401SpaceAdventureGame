using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Planets : MonoBehaviour
{
    List<GameObject> planets = new List<GameObject>();
    List<GameObject> usedPlanets = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
      Object[] sprites = Resources.LoadAll("Gezegenler");  

      for (int i =1 ; i< 17;i++){
        GameObject planet = new GameObject();
        SpriteRenderer sRenderer = planet.AddComponent<SpriteRenderer>();
        sRenderer.sprite = (Sprite)sprites[i];
        Color spriteColor=sRenderer.color;
        spriteColor.a=0.5f;
        sRenderer.color=spriteColor;
        planet.name=sprites[i].name;
        sRenderer.sortingLayerName="Planet";
        Vector2 position = planet.transform.position;
        position.x=-10;
        planet.transform.position=position;
        planets.Add(planet);


      }
    }

    public void planetAdd(float refY) {
    float height = DisplayCalculate.instance.Height;
    float width = DisplayCalculate.instance.Width;

    // 1.bölge +x +y
    float xValue1 = Random.Range(0.0f, width);
    float yValue1 = Random.Range(refY, refY + height);
    GameObject gezegen1 = RandomPlanet();
    gezegen1.transform.position = new Vector2(xValue1, yValue1);

    // 2.bölge -x +y
    float xValue2 = Random.Range(-width, 0.0f);
    float yValue2 = Random.Range(refY, refY + height);
    GameObject gezegen2 = RandomPlanet();
    gezegen2.transform.position = new Vector2(xValue2, yValue2);

    // 3.bölge -x -y
    float xValue3 = Random.Range(-width, 0.0f);
    float yValue3 = Random.Range(refY - height, refY);
    GameObject gezegen3 = RandomPlanet();
    gezegen3.transform.position = new Vector2(xValue3, yValue3);

    // 4.bölge +x -y
    float xValue4 = Random.Range(0.0f, width);
    float yValue4 = Random.Range(refY - height, refY);
    GameObject gezegen4 = RandomPlanet();
    gezegen4.transform.position = new Vector2(xValue4, yValue4);
}

    GameObject RandomPlanet(){
      if(planets.Count>0){
        int random;
        if(planets.Count==1){
          random =0;
        }else{
          random = Random.Range(0,planets.Count-1);

        } 
        GameObject planet = planets[random];
        planets.Remove(planet);
        usedPlanets.Add(planet);
        return planet;
              
      }else {
        for(int i=0;i < 8;i++){
          planets.Add(usedPlanets[i]);
        }
        usedPlanets.RemoveRange(0,8);
        int random=Random.Range(0,8);
        GameObject planet = planets[random];
        planets.Remove(planet);
        usedPlanets.Add(planet);
        return planet;
      }
    }
}
