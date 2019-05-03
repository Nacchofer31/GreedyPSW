using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void restartLevel()
    {
        Debug.Log("TRY AGAIN PREVIOUS LEVEL");
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(sceneName);
    }

    public void returningToMenu() {
        Debug.Log("PLAYER HAS GIVEN UP!");
        SceneManager.LoadScene("MainMenu");
    }
}
