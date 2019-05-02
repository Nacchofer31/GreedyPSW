using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers
{
    public bool invencibility = false;
    public bool superSpeed = false;
    public bool invisibility = false;

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
    }

    public float StopSuperSpeed()
    {
        superSpeed = false;
        return -0.2f;
    }
}
