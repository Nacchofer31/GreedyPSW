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


    public void onFruitConsumed() {
        fruitsText.fruitConsumed();
    }

    public void onCaloriesAdded(int calories) {
        caloriesText.setCalories(calories);
    }

    public float getLevelScore()
    {
        return levelScore;
    }
    public void addLevelScore(float value)
    {
        levelScore += value;
    }

    public void getNextlevel(string level) {
        timeSpent = timeCounter.getTime();
        onActiveMission();
        levelManager.setTotalTime(timeSpent);
        nextLevel = level;
        levelManager.updateTotalScore(levelScore);
        SceneManager.LoadScene(nextLevel);
    }

    public void loadCongratulationsScreen() {
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

    void onActiveMission() {
        if (thisLevel == "Level1")
        {
            checkTimeOutMission();
        }

        if (thisLevel == "Level2")
        {
            checkTimeOutMission();
        }

        if (thisLevel == "Level3")
        {
            checkPowerUsed();
        }

        if (thisLevel == "Level4")
        {
            checkPowerUsed();
        }
    }

    void checkTimeOutMission() {
        float finishingTime = missionController.getFinishingTime();
        if (timeSpent <= finishingTime)
        {
            float reward = missionController.getReward();
            addLevelScore(reward);
        }
    }

    void checkPowerUsed()
    {
        if (!player.GetPowerUpUsed())
        {
            float reward = missionController.getReward();
            addLevelScore(reward);
        }
    }

    void checkDamaged()
    {
        if (!player.GetDamaged())
        {
            float reward = missionController.getReward();
            addLevelScore(reward);
        }
    }

    void Update()
    {

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            PlayerSelected = false;
        }
        else
        { 
            PlayerSelected = true;
        }
    }

    void Tecla()
    {
        if(PlayerSelected && Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                ChangeMode();
                PauseMenuUI.SetActive(false);
            }

            else
            {
                ChangeMode();
                PauseMenuUI.SetActive(true);
            }
        }
    }


    public void ChangeMode()
    {
        if(IsPaused)
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
}
