using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node[] NodeNeighbour;
    public Vector2 Position;

    private bool IsBusy = false;

    void Start()
    {
        
    }

    public void ToBusy()
    {
        IsBusy = true;
    }

    public bool GetBusy()
    {
        return IsBusy;
    }

    public void Free()
    {
        IsBusy = false;
    }
}
