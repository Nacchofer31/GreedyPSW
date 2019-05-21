using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject Boots;
    public GameObject Shield;
    public GameObject Food;
    public GameObject Bomb;
    public GameObject Fires;
    public GameObject Life;

    public GameObject Ajustador;

    public CountDownTimer SpawnTime;

    public Node[] Nodes;

    public int frutas;
    public int i = 0;
    public int node = 0;
    public readonly int bombs = 3;
    public readonly int NumFire = 2;
    public readonly int boots = 5;
    public readonly int shields = 3;
    public readonly int lifes = 2;
    

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

        i = 0;

        while (i != bombs)
        {
            do
            {
                node = Random.Range(0, 65);
            } while (Nodes[node].GetBusy());

            Generate("Bomb", node);
            i++;
        }

        i = 0;

        while (i != NumFire)
        {
            do
            {
                node = Random.Range(0, 65);
            } while (Nodes[node].GetBusy());

            Generate("Fire", node);
            i++;
        }

        i = 0;

        while (i != boots)
        {
            do
            {
                node = Random.Range(0, 65);
            } while (Nodes[node].GetBusy());

            Generate("Boots", node);
            i++;
        }

        i = 0;

        while (i != shields)
        {
            do
            {
                node = Random.Range(0, 65);
            } while (Nodes[node].GetBusy());

            Generate("Shield", node);
            i++;
        }
    }

    void Update()
    {
        /*if(SpawnTime.getTime() % 15 == 0)
        {
            int type = Random.Range(0, 2);
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
                case 2: Generate("Bomb", node);
                    break;
                case 3: Generate("Fire", node);
                    break;
            }
        }*/
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

        else if (name == "Bomb")
        {
            Instantiate(Bomb, ((Vector3)Nodes[pos_node].Position) + Ajustador.transform.position, Nodes[pos_node].transform.rotation);
            Nodes[pos_node].ToBusy();
        }

        else if (name == "Fire")
        {
            Instantiate(Fires, ((Vector3)Nodes[pos_node].Position) + Ajustador.transform.position, Nodes[pos_node].transform.rotation);
            Nodes[pos_node].ToBusy();
        }

        else if (name == "Heart")
        {
            Instantiate(Life, ((Vector3)Nodes[pos_node].Position) + Ajustador.transform.position, Nodes[pos_node].transform.rotation);
            Nodes[pos_node].ToBusy();
        }
    }
}
