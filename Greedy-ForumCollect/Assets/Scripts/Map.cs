using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public bool IsPaused;
    public bool PlayerSelected;
    public MissionController missionController;

    [Header ("Level UI")]
    public ScoreText scoreText;
    public FruitsText fruitsText;
    public CaloriesScript caloriesText;
 

    public GameObject ShieldUI;
    public GameObject BootsUI;
    public GameObject FireUI;

    public CountDownTimer timeCounter;

    public Character_mov player;
    public GameObject PauseMenuUI;
    public GameObject PowersUI;

    [Header ("Level Music")]
    public AudioSource levelMusic;

    //private variables
    private SoundManager soundManager;
    private LevelManager levelManager;
    private Animator animacion;
    private float levelScore;
    private float timeSpent;
    private string nextLevel;
    private string thisLevel;


    public void OnFruitConsumed()
    {
        fruitsText.FruitConsumed();
    }

    public void OnCaloriesAdded(int calories)
    {
        caloriesText.IncrementCalories(calories);
    }

    public float GetLevelScore()
    {
        return levelScore;
    }

    public void AddLevelScore(float value)
    {
        levelScore += value;
    }

    public void ChangeMode()
    {
        if (IsPaused)
        {
            Time.timeScale = 1f;
            IsPaused = false;
        }

        else
        {
            Time.timeScale = 0f;
            IsPaused = true;
        }
    }

    public void GetNextlevel(string level)
    {
        timeSpent = timeCounter.getTime();
        onActiveMission();
        levelManager.SetTotalTime(timeSpent);
        nextLevel = level;
        levelManager.UpdateTotalScore(levelScore);
        SceneManager.LoadScene(nextLevel);
    }

    public void loadCongratulationsScreen()
    {
        levelManager.loadCongratulationsScreen();

    }

    void Start()
    {
        thisLevel = SceneManager.GetActiveScene().name;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (thisLevel == "Level1")
        {
            IsPaused = true;
            Time.timeScale = 0f;
        }
        else
        {
            IsPaused = false;
            Time.timeScale = 1f;
        }
    }

    void onActiveMission()
    {
        if (thisLevel == "Level1")
        {
            CheckTimeOutMission();
        }

        if (thisLevel == "Level2")
        {
            CheckTimeOutMission();
        }

        if (thisLevel == "Level3")
        {
            CheckPowerUsed();
        }

        if (thisLevel == "Level4")
        {
            CheckPowerUsed();
        }
    }

    void CheckTimeOutMission()
    {
        float finishingTime = missionController.GetFinishingTime();
        if (timeSpent <= finishingTime)
        {
            float reward = missionController.GetReward();
            AddLevelScore(reward);
        }
    }

    void CheckPowerUsed()
    {
        if (!player.GetPowerUpUsed())
        {
            float reward = missionController.GetReward();
            AddLevelScore(reward);
        }
    }

    void CheckDamaged()
    {
        if (!player.GetDamaged())
        {
            float reward = missionController.GetReward();
            AddLevelScore(reward);
        }
    }
}
