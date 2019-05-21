using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCompletedController : MonoBehaviour
{
    public Text finalScoreText;
    public Text timeText;
    private LevelManager levelManager;
    private float totalObtainedScore;
    private float totalTimeSpent;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        totalTimeSpent = levelManager.getTotalTime();
        totalObtainedScore = levelManager.getTotalScore();
        finalScoreText.text = "SCORE: " + totalObtainedScore.ToString("0");
        timeText.text = "TOTAL TIME: " + totalTimeSpent.ToString();

    }
}
