using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    public bool invencibility;
    public bool superSpeed;
    public bool invisibility;

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

    public void Activate()
    {
        if(superSpeed)
        {
            Player.RunSpeed += 0.2f;
            Invoke("SPOff", 1);
        }
    }

    void SPOff()
    {
        Debug.Log("-hola");
        Player.RunSpeed += -0.2f;
    }
}
