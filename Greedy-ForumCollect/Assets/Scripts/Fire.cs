using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Interactable
{
    public Character_mov player;
    public Map map;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            float i = 0;
            while (i != 4)
            {
                Invoke("Touching", i * 5);               
                i++;
            }
            Invoke("StopFiring", (i - 1) * 5);
        }
    }

    void Touching()
    {
        player.Hurt(0.1f);
    }

    void StopFiring()
    {
        map.FireUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
    }
}
