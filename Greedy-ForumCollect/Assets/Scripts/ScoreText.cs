using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Map map;
    public Text scoreText;
    private float levelScore;



    // Start is called before the first frame update
    void Start()
    {
        levelScore = map.getLevelScore();
        scoreText.text = "SCORE: " + levelScore;
    }

    // Update is called once per frame
    void Update()
    {
        levelScore = map.getLevelScore();
        printScore();
    }

    void printScore() {
        scoreText.text = "SCORE: " + levelScore;
    }
}
