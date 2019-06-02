using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    private int rand;
    public bool canEat = false;

    public Sprite[] Sprite_Pic;
    public Sprite Sprite_selected;
    public int calories;

    void Start()
    {
        rand = Random.Range(0, Sprite_Pic.Length);
        Sprite_selected = Sprite_Pic[rand];
        GetComponent<SpriteRenderer>().sprite = Sprite_selected;
        setCalories(Sprite_selected.name.Substring(4, 1));
    }

    void setCalories(string calText)
    {
        switch (calText)
        {
            case "S":
                calories = 40;
                break;
            case "A":
                calories = 20;
                break;
            case "B":
                calories = 10;
                break;
        }
    }

}
