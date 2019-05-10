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

    private void Awake()
    {
        myAnimator = Player.gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        Time.timeScale = 0f;
        myAnimator = Player.gameObject.GetComponent<Animator>();
        //Debug.Log(Resources.Load("Player/Green/Green.controller").name);
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
        myAnimator.runtimeAnimatorController = 
            (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Assets/Graphics/Animations/Player/Blue/Blue.controller", 
            typeof(RuntimeAnimatorController)));

    }

    public void Green()
    {
        myAnimator.runtimeAnimatorController = Resources.Load("Assets/Graphics/Animations/Player/Green/Green.controller") as RuntimeAnimatorController;
           
        SelectMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }
}
