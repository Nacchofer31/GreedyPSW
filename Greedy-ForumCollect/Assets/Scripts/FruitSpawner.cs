using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    private int rand;
    public bool canEat = false;

    public Sprite[] Sprite_Pic;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, Sprite_Pic.Length);
        GetComponent<SpriteRenderer>().sprite = Sprite_Pic[rand];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
