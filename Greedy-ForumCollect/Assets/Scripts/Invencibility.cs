using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invencibility : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public IEnumerable GetInvulnerable(Collider2D player, Collider2D enemy)
    {
        Physics2D.IgnoreCollision(player, enemy, true);
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreCollision(player, enemy, false);

    }
}
