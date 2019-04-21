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

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, Sprite_Pic.Length);
        Sprite_selected = Sprite_Pic[rand];
        GetComponent<SpriteRenderer>().sprite = Sprite_selected;
        Debug.Log(Sprite_selected.name.Substring(4, 1));
        switch (Sprite_selected.name.Substring(4,1))
        {
            case "S":
                calories = 20;
                break;
            case "A":
                calories = 10;
                break;
            case "B":
                calories = 5;
                break;
        }

    }

}
