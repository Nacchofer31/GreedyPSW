using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    private float currentTime;

    [SerializeField] Text countdownText;

    public float getTime() {
        return currentTime;
    }

    void Start()
    {
        currentTime = 0f;        
    }

    void Update()
    {
        if (!PauseMenu.IsPaused)
        {
            currentTime += 1 * Time.deltaTime;
            printTimer();
        }
    }

    void printTimer()
    {
        countdownText.text = "TIME: " + currentTime.ToString("0");
    }
}
