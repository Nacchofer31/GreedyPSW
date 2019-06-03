using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaloriesScript : MonoBehaviour
{
    private static int caloriesValue = 0;
    Text caloriesText;

    public void incrementCalories(int value) {
        caloriesValue += value;
    }

    public int getCalories() {
        return caloriesValue;
    }

    public void setCalories(int newCaloriesValue)
    {
        caloriesValue = newCaloriesValue;
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
