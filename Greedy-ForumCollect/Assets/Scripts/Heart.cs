using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Interactable
{
    public Character_mov Player;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player.LifeUp();
    }
}
