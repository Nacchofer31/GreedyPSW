using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject questText;

    public void Resume()
    {
        questText.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        AudioListener.pause = false;
    }

    private void Start()
    {
        Resume();
    }

    void Update()
    {
        if (!optionsMenuUI.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPaused)
                {
                    Resume();
                }

                else if (!IsPaused)
                {
                    Pause();
                }
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        questText.SetActive(false);
        IsPaused = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    private void FixedUpdate()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }

            else if (!IsPaused)
            {
                Pause();
            }
        }*/
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        AudioListener.pause = false;
    }

    public void Save()
    {

    }


}
