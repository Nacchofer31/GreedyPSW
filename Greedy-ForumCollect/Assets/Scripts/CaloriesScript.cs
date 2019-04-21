using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaloriesScript : MonoBehaviour
{
    public static int caloriesValue = 0;
    Text caloriesText;
    // Start is called before the first frame update
    void Start()
    {
        caloriesText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        caloriesText.text = "Calories: " + caloriesValue;
    }
}
