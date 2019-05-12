using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : Interactable
{
    public bool invencibility = false;
    public bool superSpeed = false;
    public bool invisibility = false;

    public Character_mov Player;

    public void StartInvulnerable()
    {
        invencibility = true;
    }

    public void StopInvulnerable()
    {
        invencibility = false;
    }

    public float StartSuperSpeed()
    {
        superSpeed = true;
        return 0.2f;

        //Player.RunSpeed += 0.2f;
        //return 0.2f;
    }

    public float StopSuperSpeed()
    {
        superSpeed = false;
        return -0.2f;
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("Picking up item");
        //Instantiate(effect, transform.position, Quaternion.identity);
        StartSuperSpeed();
        Destroy(gameObject);
    }
}
