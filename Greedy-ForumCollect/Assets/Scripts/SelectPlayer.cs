using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class SelectPlayer : MonoBehaviour
{
    public static bool IsPaused = true;

    public GameObject SelectMenuUI;
    public GameObject Player;

    private Animator myAnimator;
    public RuntimeAnimatorController RedPlayer;
    public RuntimeAnimatorController BluePlayer;
    public RuntimeAnimatorController GreenPlayer;
    public RuntimeAnimatorController YellowPlayer;

    private void Awake()
    {
        myAnimator = Player.gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        Time.timeScale = 0f;
        myAnimator = Player.gameObject.GetComponent<Animator>();
        Debug.Log(myAnimator.runtimeAnimatorController.ToString());
        Debug.Log(Resources.Load("Green.controller").ToString());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
            AudioListener.pause = false;
        }
    }

    public void Resume()
    {
        SelectMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        AudioListener.pause = false;
    }

    public void Blue()
    {
        myAnimator.runtimeAnimatorController = BluePlayer;

        SelectMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }

    public void Green()
    {
        myAnimator.runtimeAnimatorController = GreenPlayer;
           
        SelectMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }

    public void Red()
    {
        myAnimator.runtimeAnimatorController = RedPlayer;

        SelectMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }

    public void Yellow()
    {
        myAnimator.runtimeAnimatorController = YellowPlayer;

        transform.gameObject.SetActive(false);
        Time.timeScale = 1f;

    }
}
