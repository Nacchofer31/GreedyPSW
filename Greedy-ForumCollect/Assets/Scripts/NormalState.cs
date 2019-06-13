using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : State
{

    public NormalState(Character_mov player): base(player)
    {
    }

    public override void CheckPower()
    {

        if (player.PowerUp != null)
        {
            player.setState(new PowerState(player));
        }
    }
}
