using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaloriesScript : MonoBehaviour
{
    private static int caloriesValue = 0;
    Text caloriesText;

    public void IncrementCalories(int value) {
        caloriesValue += value;
    }

    public int GetCalories() {
        return caloriesValue;
    }

    public void SetCalories(int newCaloriesValue)
    {
        caloriesValue = newCaloriesValue;
    }

    void Start()
    {
        caloriesValue = 0;
        caloriesText = GetComponent<Text>();
    }

    void Update()
    {
        caloriesText.text = "CALORIES: " + caloriesValue;
    }

}
