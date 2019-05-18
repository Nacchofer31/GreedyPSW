using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class SelectPlayer : MonoBehaviour
{

    public GameObject SelectMenuUI;
    public GameObject Player;
    public Map map;

    private Animator myAnimator;
    public RuntimeAnimatorController RedPlayer;
    public RuntimeAnimatorController BluePlayer;
    public RuntimeAnimatorController GreenPlayer;
    public RuntimeAnimatorController YellowPlayer;

    void Start()
    {
        myAnimator = Player.gameObject.GetComponent<Animator>();
        if(SceneManager.GetActiveScene().name!="Level1")
        {
            //myAnimator.runtimeAnimatorController =
            SelectMenuUI.SetActive(false);
            map.PlayerSelected = true;
            map.ChangeMode();
        }
    }

    void Update()
    {
        if (!map.PlayerSelected && Input.GetKeyDown(KeyCode.Escape))
        {

            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
            AudioListener.pause = false;
        }
    }

    public void Resume()
    {
        SelectMenuUI.SetActive(false);
        map.ChangeMode();
        AudioListener.pause = false;
    }

    public void Blue()
    {
        myAnimator.runtimeAnimatorController = BluePlayer;

        StartGame();

    }

    public void Green()
    {
        myAnimator.runtimeAnimatorController = GreenPlayer;
           
        SelectMenuUI.SetActive(false);
        map.PlayerSelected = true;
        map.ChangeMode();

    }

    public void Red()
    {
        myAnimator.runtimeAnimatorController = RedPlayer;

        SelectMenuUI.SetActive(false);
        map.PlayerSelected = true;
        map.ChangeMode();

    }

    public void Yellow()
    {
        myAnimator.runtimeAnimatorController = YellowPlayer;

        transform.gameObject.SetActive(false);
        map.PlayerSelected = true;
        map.ChangeMode();

    }

    void StartGame()
    {
        SelectMenuUI.SetActive(false);
        map.PlayerSelected = true;
        map.ChangeMode();
    }
}
