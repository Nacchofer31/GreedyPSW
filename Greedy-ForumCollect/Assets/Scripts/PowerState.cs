using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerState : State
{
    public Powers power;

    public PowerState(Character_mov player) : base(player)
    {
    }

    public override void CheckPower()
    {

        if (player.PowerUp != null)
        {
            power = player.PowerUp.GetComponent<Powers>();
            string PowerUpName = player.PowerUp.name;

            if (PowerUpName == "Boots")
            {
                power.Activate();
                player.SuperSpeedOn = true;
                player.map.BootsUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

                player.PowerUp.gameObject.SetActive(false);
                player.SetAnimations();
                player.PowerUp.Interact();
                player.RemoveFocus();
                player.Invoke("SPOff", 5f);
            }

            else if (PowerUpName == "Shield")
            {
                power.Activate();
                player.InvulOn();
                player.map.ShieldUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

                player.PowerUp.gameObject.SetActive(false);
                player.PowerUp.Interact();
                player.RemoveFocus();
                player.Invoke("InvulOff", 5f);
            }
        
        }
    }
}
