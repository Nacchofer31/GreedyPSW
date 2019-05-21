using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionController : MonoBehaviour
{
    public Map map;
    private float reward;
    private float finishingTime = 0f;

    public float getFinishingTime() {
        return finishingTime;
    }

    public float getReward() {
        return reward;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            reward = 150;
            finishingTime = 30f;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            reward = 175;
            finishingTime = 50f;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            reward = 200;
            finishingTime = 50f;
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            reward = 225;
            finishingTime = 50f;
        }
        else if (SceneManager.GetActiveScene().name == "Level_5")
        {
            reward = 250;
            finishingTime = 50f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene().name == "Level1"))
        {
            reward = 150;
            finishingTime = 30f;
        }
        else if ((SceneManager.GetActiveScene().name == "Level2"))
        {
            reward = 175;
            finishingTime = 50f;
        }
        else if ((SceneManager.GetActiveScene().name == "Level3"))
        {
            reward = 200;
        }
        else if ((SceneManager.GetActiveScene().name == "Level4"))
        {
            reward = 225;
        }
        else if ((SceneManager.GetActiveScene().name == "Level_5"))
        {
            reward = 250;
        }
    }
    

    
}
