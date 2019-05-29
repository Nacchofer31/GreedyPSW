using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class SelectPlayer : MonoBehaviour
{
    public GameObject SelectPlayerUI;
    public GameObject SelectMenuUI;
    public GameObject Player;
    public Map map;

    private Animator myAnimator;
    private LevelManager levelManager;
    public RuntimeAnimatorController RedPlayer;
    public RuntimeAnimatorController BluePlayer;
    public RuntimeAnimatorController GreenPlayer;
    public RuntimeAnimatorController YellowPlayer;

    void Start()
    {
        myAnimator = Player.gameObject.GetComponent<Animator>();
        if(SceneManager.GetActiveScene().name!="Level1")
        {
            myAnimator.runtimeAnimatorController = levelManager.GetPlayerAnimation();
            SelectMenuUI.SetActive(false);
            map.PlayerSelected = true;
            SelectPlayerUI.SetActive(false);
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
        levelManager.SetPlayerAnimation(BluePlayer);
        
        StartGame();
    }

    public void Green()
    {
        myAnimator.runtimeAnimatorController = GreenPlayer;
        levelManager.SetPlayerAnimation(GreenPlayer);

        StartGame();
    }

    public void Red()
    {
        myAnimator.runtimeAnimatorController = RedPlayer;
        levelManager.SetPlayerAnimation(RedPlayer);

        StartGame();
    }

    public void Yellow()
    {
        myAnimator.runtimeAnimatorController = YellowPlayer;
        levelManager.SetPlayerAnimation(YellowPlayer);

        StartGame();
    }

    void StartGame()
    {
        SelectMenuUI.SetActive(false);
        map.PlayerSelected = true;
        map.ChangeMode();
        SelectPlayerUI.SetActive(false);
    }
}
