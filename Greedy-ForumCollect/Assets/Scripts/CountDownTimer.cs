using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    float startingTime = 300f;
    float currentTime = 0f;
    [SerializeField] Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= 0)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = "Tiempo: " + currentTime.ToString("0.00");
        }
        else {
            countdownText.text = "FIN!";
        }
    }
}
