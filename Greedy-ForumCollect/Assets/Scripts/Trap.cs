using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : Interactable
{
    private float currentHealth;


    [Header("Physics")]
    public Animator animations;
    Rigidbody2D rigidBody;

    protected HealthBar healthBar;
    protected Character_mov mainCharacter;

    public abstract void OnTriggerEnter2D(Collider2D collision);
}
