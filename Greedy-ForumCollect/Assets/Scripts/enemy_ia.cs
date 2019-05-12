using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_ia : MonoBehaviour{

    private float temporizadorUltimaDireccion;
    //private readonly float temporizadorCambioDeDireccion = 3f;
    public Vector2 direccion = Vector2.zero;
    private Vector2 movimientoPorSegundo;

    [Header("Basic Elements")]
    public Vector2 InitialPosition;

    public Node ActualNode, TargetNode;

    public float runSpeed = 0.5f;
    Rigidbody2D rb;

    public int error = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitialPosition = rb.transform.position;
        temporizadorUltimaDireccion = 0f;
        ChooseNewNode(ActualNode);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Time.time - temporizadorUltimaDireccion > temporizadorCambioDeDireccion){
            
            temporizadorUltimaDireccion = Time.time;
            ChooseNextMove();
        }
        
        Move();
        Orientation();*/

        //ChooseNewNode(ActualNode);

        Move();
        
    } 

    void ChooseNextMove()
    {

         direccion = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
         movimientoPorSegundo = direccion * runSpeed;  

    }

    void FixedUpdate()
    {
        //Move();
    }

    void Move()
    {
        if (transform.position != TargetNode.transform.position)
        {
            transform.position = new Vector2(transform.position.x + (movimientoPorSegundo.x * Time.deltaTime),
            transform.position.y + (movimientoPorSegundo.y * Time.deltaTime));
        }
        
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
            ChooseNewNode(ActualNode);
        }

        else if(other.gameObject.CompareTag("Node"))
        {
            Node NewNode = other.gameObject.GetComponent<Node>();
            ChooseNewNode(NewNode);
        }

        else if(other.gameObject.CompareTag("Enemy"))
        {
            movimientoPorSegundo = movimientoPorSegundo * -1;
        }
    }

    void ChooseNewNode(Node Act)
    {
        bool NewPosition = false;
        Node PreviousNode = ActualNode;
        ActualNode = Act;
        while (!NewPosition) {
            int pos = Random.Range(0, Act.NodeNeighbour.Length);
            Node newNode = ActualNode.NodeNeighbour[pos];
            if (newNode != PreviousNode)
            {
                if(newNode.Position.x == ActualNode.Position.x)
                {

                    if (newNode.Position.y < ActualNode.Position.y)
                    {
                        direccion = Vector2.down;
                    }
                    else
                    {
                        direccion = Vector2.up;
                    }
                }
                else
                {
                    if (newNode.Position.x < ActualNode.Position.x)
                    {
                        direccion = Vector2.left;
                        transform.localScale = new Vector3(-0.23215f, 0.23215f, 0.23215f);
                    }
                    else
                    {
                        direccion = Vector2.right;
                        transform.localScale = new Vector3(0.23215f, 0.23215f, 0.23215f);
                    }
                }         
                movimientoPorSegundo = direccion * runSpeed;
                NewPosition = true;
                TargetNode = newNode;
                
            }
        }
    }

    public void Restart()
    {
        rb.transform.position = InitialPosition;
        Start();
    }

}
