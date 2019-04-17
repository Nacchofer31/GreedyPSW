using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_ia : MonoBehaviour{

    private float temporizadorUltimaDireccion;
    private readonly float temporizadorCambioDeDireccion = 3f;
    private Vector2 direccion = Vector2.zero;
    private Vector2 movimientoPorSegundo;

    public float runSpeed = 0.5f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        temporizadorUltimaDireccion = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - temporizadorUltimaDireccion > temporizadorCambioDeDireccion){
            
            temporizadorUltimaDireccion = Time.time;
            ChooseNextMove();
        }
        
        Move();
        Orientation();
        
    } 

    void ChooseNextMove()
    {

         direccion = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
         movimientoPorSegundo = direccion * runSpeed;  

    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.position = new Vector2(transform.position.x + (movimientoPorSegundo.x * Time.deltaTime), 
        transform.position.y + (movimientoPorSegundo.y * Time.deltaTime));
    }


    void Orientation()
    {
        if(direccion == Vector2.right)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        else if(direccion == Vector2.left)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Map"))
        {
            ChooseNextMove();
        }
    }

}
