using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected Character_mov player;

    public abstract void CheckPower();

    public virtual void OnStateEnter()
    {
    }

    public virtual void OnStateExit()
    {
    }

    public State(Character_mov player)
    {
        this.player = player;
    }

}
