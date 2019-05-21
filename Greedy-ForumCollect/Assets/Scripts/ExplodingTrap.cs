using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingTrap : Trap
{
    public Collider2D trapCollider;
    [Header("Sound")]
    public AudioClip explosionSound;

    private bool hasExploded;
    // Start is called before the first frame update
    void Start()
    {
        hasExploded = false;
        healthBar = GetComponent<HealthBar>();
        mainCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_mov>();
    }

 

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hasExploded == false)
            {
                hasExploded = true;
                animations.SetBool("IsExploding", true);
                SoundManager.instance.PlaySingle(explosionSound);
                mainCharacter.Hurt(0.33f);
                Destroy(gameObject, .7f);
            }
            
        }
    }
}
