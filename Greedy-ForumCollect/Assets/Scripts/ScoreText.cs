using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Map map;
    public Text scoreText;
    private float levelScore;

    void Start()
    {
        levelScore = map.GetLevelScore();
        scoreText.text = "SCORE: " + levelScore;
    }

    void Update()
    {
        levelScore = map.GetLevelScore();
        printScore();
    }

    void printScore() {
        scoreText.text = "SCORE: " + levelScore;
    }
}
