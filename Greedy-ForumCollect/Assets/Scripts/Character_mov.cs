using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_mov : MonoBehaviour {

    //Initial variables
    private Vector2 direction = Vector2.zero;
    private Vector2 InitialPosition;
    int life;

    Rigidbody2D rb;
    public float RunSpeed = 0.5f;

    public GameObject Lifes;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitialPosition = rb.position;
        life = 3;
    }

    void Update()
    {
        Tecla();

        Orientation();

        Move();
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

        else if(Input.GetKey(KeyCode.Space))
        {

        }
    }

    // Update is called once per frame
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
            Die();
        }
    }

    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        if(life > 0)
        {
            Lifes.transform.Find("Life_1").gameObject.SetActive(false);
            
            rb.transform.position = InitialPosition;
        }
        
    }

}
