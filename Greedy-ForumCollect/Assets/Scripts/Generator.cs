using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject Boots;
    public GameObject Shield;

    public CountDownTimer SpawnTime;

    public Node[] Nodes;

    void Start()
    {
        
    }

    void Update()
    {
        if(SpawnTime.getTime() % 15f == 0f)
        {
            int type = Random.Range(0, 1);
            int node = Random.Range(0, 65);

            switch(type)
            {
                case 0: Generate("Boots", node);
                    break;
                case 1: Generate("Shield", node);
                    break;
            }
        }

        else if(Input.GetKeyDown(KeyCode.Space))
        {
            Generate("Boots", 3);
        }
    }

    void Generate(string name, int pos_node)
    {
        if(name == "Boots")
        {
             Instantiate(Boots, Nodes[pos_node].transform.position, Nodes[pos_node].transform.rotation);
        }
    }
}
