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



    public Character_mov player;
    public GameObject PauseMenuUI;
    [Header ("Level Music")]
    public AudioSource levelMusic;

    private SoundManager soundManager;
    private LevelManager levelManager;
    private float levelScore;
    private string nextLevel;

    public float getLevelScore() {
        return levelScore;
    }
    public void addLevelScore(float value) {
        levelScore += value;
    }
    public void getNextlevel(string level) {
        nextLevel = level;
        SceneManager.LoadScene(nextLevel);

    }

    void Start()
    {
        levelManager = gameObject.GetComponent<LevelManager>();
        IsPaused = true;
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            PlayerSelected = false;
        }
        else {
            PlayerSelected = true;
        }
        Time.timeScale = 0f;


    }

    void Update()
    {
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
}
