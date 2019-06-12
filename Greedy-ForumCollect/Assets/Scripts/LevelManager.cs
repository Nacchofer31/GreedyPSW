using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public RuntimeAnimatorController playerAnimation;
    public Map map;
    public HighScore NewScore;
    public static LevelManager instance = null;
    private float totalScore;
    public float rankingScore;
    private string nextLevel;
    private int lastSceneToLoad;
    private float totalTime;

    public float GetTotalScore()
    {
        return totalScore;
    }

    public void SetTotalScore(float score)
    {
        totalScore = score;
    }

    public void UpdateTotalScore(float levelScore)
    {
        totalScore = levelScore;
        rankingScore = totalScore;
    }

    public void SetTotalTime(float time)
    {
        totalTime += time;
    }

    public float GetTotalTime()
    {
        return totalTime;
    }

    public void SetPlayerAnimation(RuntimeAnimatorController animation)
    {
        playerAnimation = animation;
    }

    public RuntimeAnimatorController GetPlayerAnimation()
    {
        return playerAnimation;
    }

    public LevelManager(float score) {
        totalScore = score;
    }
    
    public void loadNewLevel(string level)
    {
        nextLevel = level;
        UpdateTotalScore(map.GetLevelScore());
        SceneManager.LoadScene(nextLevel);
        
    }

    public void loadCongratulationsScreen() {
        lastSceneToLoad = SceneManager.GetActiveScene().buildIndex + 2;
        SceneManager.LoadScene(lastSceneToLoad);
    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        nextLevel = SceneManager.GetActiveScene().name;
        map = GameObject.FindObjectOfType<Map>();
        if(nextLevel == "Level1")
        {
            totalScore = 0;
            totalTime = 0;
        }

        if (map != null)
        {
            map.AddLevelScore(totalScore);
        }     
    }

    void Update()
    {
        if (nextLevel != SceneManager.GetActiveScene().name)
        {
            nextLevel = SceneManager.GetActiveScene().name;
            map = GameObject.FindObjectOfType<Map>();
            if (map != null)
            {
                map.AddLevelScore(totalScore);
            }
        }
    }

}

    



