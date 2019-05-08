using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    private float currentTime;

    [SerializeField] Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.IsPaused)
        {
            currentTime += 1 * Time.deltaTime;
            printTimer();
        }
    }


    void printTimer() {
        countdownText.text = "TIME: " + currentTime.ToString("0");
    }
}
