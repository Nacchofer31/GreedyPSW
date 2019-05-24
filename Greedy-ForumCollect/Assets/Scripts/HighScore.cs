using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{

    public Text Score;
    public float ActualScore;
    public float NewScore;
    public LevelManager LevelManager;


    // Start is called before the first frame update
    void Start()
    {
        ActualScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
        NewScore = LevelManager.rankingScore;
        if (ActualScore < NewScore)
        {
            Score.text = NewScore.ToString("0");
        }
    }
}
