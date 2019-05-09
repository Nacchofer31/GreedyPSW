using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingTrap : Trap
{
    public Collider2D trapCollider;
    // Start is called before the first frame update
    void Start()
    {
        //healthBar = GetComponent<HealthBar>();
        mainCharacter = GetComponent<Character_mov>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!mainCharacter.powers.invencibility)
            {
                Debug.Log("YOU HIITTTTTTTTTTTTT ITT!!!!!!!!!!!!!");
                healthBar.setSize(healthBar.getSize() + 0.3f);
            }
        }
    }
}
