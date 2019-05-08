using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSize(float sizeNormalize)
    {
        if (sizeNormalize < 0f) { bar.localScale = new Vector3(0f, 1f); }
        else if (sizeNormalize >   1f) { bar.localScale = new Vector3(0f, 1f); }
        else { bar.localScale = new Vector3(sizeNormalize, 1f); }
    }

    public float getSize()
    {
        return bar.localScale.x;
    }

    public void setColor (Color color)
    {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
}
