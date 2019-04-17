using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
                Resume();
            }

            else if(!IsPaused)
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    private void FixedUpdate()
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

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        AudioListener.pause = false;
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
