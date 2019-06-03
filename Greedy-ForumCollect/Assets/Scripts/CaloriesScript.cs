using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaloriesScript : MonoBehaviour
{
    public static int caloriesValue = 0;
    Text caloriesText;

    public void setCalories(int value) {
        caloriesValue += value;
    }

    // Start is called before the first frame update
    void Start()
    {
        caloriesValue = 0;
        caloriesText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        caloriesText.text = "CALORIES: " + caloriesValue;
    }

}
