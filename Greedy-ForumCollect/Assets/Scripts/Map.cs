using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public bool IsPaused;
    public bool PlayerSelected;

    public Character_mov player;
    public GameObject PauseMenuUI;
    [Header ("Level Music")]
    public AudioSource levelMusic;

    private SoundManager soundManager;

    
    void Start()
    {
        IsPaused = true;
        PlayerSelected = false;
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
