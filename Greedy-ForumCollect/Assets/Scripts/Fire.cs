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
            float i = 0;
            touching();
            while (i != 4)
            {
                Invoke("touching", i * 5);
                
                i++;
            } 
        }
    }

    void touching()
    {
        player.Hurt(0.1f);
    }

    void StopFiring()
    {
        //player.Hurt()
    }
}
