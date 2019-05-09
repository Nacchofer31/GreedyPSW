using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : Interactable
{
    private float currentHealth;

    [Header("Physics")]
    Animator animations;
    Rigidbody2D rigidBody;

    public HealthBar healthBar;
    public Character_mov mainCharacter;

    public abstract void OnTriggerEnter2D(Collider2D collision);
}
