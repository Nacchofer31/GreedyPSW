using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject Boots;
    public GameObject Shield;
    public GameObject Food;

    public GameObject Ajustador;

    public CountDownTimer SpawnTime;

    public Node[] Nodes;

    public int frutas;
    private int i = 0;
    private int node = 0;
    

    void Start()
    {
        while(i != frutas)
        {
            do
            {
                node = Random.Range(0, 65);
            } while (Nodes[node].GetBusy());
            
            Generate("Food", node);
            i++;
        }
    }

    void Update()
    {
        if(SpawnTime.getTime() % 15 == 0)
        {
            int type = Random.Range(0, 1);
            do
            {
                node = Random.Range(0, 65);
            } while (Nodes[node].GetBusy());

            switch (type)
            {
                case 0: Generate("Boots", node);
                    break;
                case 1: Generate("Shield", node);
                    break;
            }
        }
    }

    void Generate(string name, int pos_node)
    {
        if(name == "Boots")
        {
            Instantiate(Boots, ((Vector3) Nodes[pos_node].Position) + Ajustador.transform.position, Nodes[pos_node].transform.rotation);
            Nodes[pos_node].ToBusy();
        }

        else if(name == "Shield")
        {
            Instantiate(Shield, ((Vector3)Nodes[pos_node].Position) + Ajustador.transform.position, Nodes[pos_node].transform.rotation);
            Nodes[pos_node].ToBusy();
        }

        else if(name == "Food")
        {
            Instantiate(Food, ((Vector3)Nodes[pos_node].Position) + Ajustador.transform.position, Nodes[pos_node].transform.rotation);
            Nodes[pos_node].ToBusy();
        }
    }
}
