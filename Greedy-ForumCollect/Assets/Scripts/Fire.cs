using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Interactable
{
    public Character_mov player;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            int i = 0;
            while (i != 5)
            {
                player.Hurt(0.1f);
                i++;
            } 
        }
    }

    void StopFiring()
    {
        //player.Hurt()
    }
}
