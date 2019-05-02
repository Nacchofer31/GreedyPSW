﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_mov : MonoBehaviour {

    //Initial variables
    private Vector2 direction = Vector2.zero;
    private Vector2 InitialPosition;
    private float currentHealth;
    private bool over100 = false;

    int life;

    [Header("Physics")]
    Collider2D CollisionDetector;
    Rigidbody2D rb;

    public float RunSpeed = 0.5f;

    public GameObject Lifes;
    public GameObject Foods;
    public Interactable focus;
    public HealthBar healthBar;

    [Header("Powers")]
    public Powers powers;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitialPosition = rb.position;
        life = 3;
        healthBar.setSize(1f);
        powers = new Powers();
    }

    void Update()
    {
        Tecla();

        Orientation();

        Move();

        FocusOut();
    }

    void Tecla()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }

        else if (Input.GetKey(KeyCode.Space))
        {
            if (focus != null && focus.CompareTag("Food"))
            {
                FruitSpawner fruit = focus.GetComponent<FruitSpawner>();
                CaloriesScript.caloriesValue += fruit.calories;

                if (CaloriesScript.caloriesValue >= 100 && !over100) { healthBar.setSize(healthBar.getSize() + 0.1f); over100 = true; }

                focus.Interact();
                RemoveFocus();
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(!powers.invencibility)
            {
                powers.StartInvulnerable();
                Debug.Log("Invecibility ON");
            }
            else
            {
                powers.StopInvulnerable();
                Debug.Log("Invecibility OFF");
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!powers.superSpeed)
            {
                RunSpeed += powers.StartSuperSpeed();
                Debug.Log("SuperSpeed ON");
            }
            else
            {
                RunSpeed += powers.StopSuperSpeed();
                Debug.Log("SuperSpeed OFF");
            }
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.localPosition += (Vector3)(direction * RunSpeed) * Time.deltaTime;
        direction = Vector2.zero;
    }

    void Orientation()
    {
        if (!PauseMenu.IsPaused)
        {

            if (direction == Vector2.right)
            {
                transform.localScale = new Vector3(0.23215f, 0.23215f, 1);
            }

            else if (direction == Vector2.left)

            {
                transform.localScale = new Vector3(-0.23215f, 0.23215f, 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(!powers.invencibility)
            {
                powers.StartInvulnerable();
                Die();
                currentHealth = healthBar.getSize();
                healthBar.setSize(currentHealth - 0.3f);
            }
            else
            {
                enemy_ia Enemy = (enemy_ia) other.gameObject.GetComponent<enemy_ia>();
                KillEnemy(Enemy);
            }
                

        }
        if(other.gameObject.CompareTag("Food"))
        {
            Interactable newFocus = other.GetComponent<Fruit>();
            SetFocus(newFocus);
        }
    }

    void Die()
    {
        Respawn();
        powers.StopInvulnerable();
    }

    void KillEnemy(enemy_ia other)
    {
        other.Restart();
    }

    void Respawn()
    {
        if(life > 1)
        {
            Lifes.transform.Find("Life_" + (4-life).ToString()).gameObject.SetActive(false);
            life--;
            
            rb.transform.position = InitialPosition;
        }
        else
        {
            Debug.Log("You Died");
            SceneManager.LoadScene("MainMenu");
        }
        
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if(focus != null)
            {
                focus.onDefocused();
            }
            focus = newFocus;
        }
        newFocus.onFocused(transform);
        

    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.onDefocused();
        }

        focus = null;
    }

    void FocusOut()
    {
        if(focus != null)
        {
            float distance = Vector3.Distance(rb.transform.position, focus.transform.position);
            if (distance - 1f > focus.radius)
            {
                RemoveFocus();
            }
        }
    }

}
