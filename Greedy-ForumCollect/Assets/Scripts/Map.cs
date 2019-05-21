using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public bool IsPaused;
    public bool PlayerSelected;

    [Header ("Level UI")]
    public ScoreText scoreText;
    public FruitsText fruitsText;


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
    private float levelScore;
    private float timeSpent;
    private string nextLevel;

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
        string thisLevel = SceneManager.GetActiveScene().name;
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
        //Tecla();
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

    void ActiveUI(int type)
    {
        switch(type)
        {
            //case 0:  
        }
    }
}
