using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private string previousScene;

    public void chargingScene(string scene) {
        previousScene = scene;
    }

    public void restartLevel()
    {
        Debug.Log("TRY AGAIN PREVIOUS LEVEL");
        SceneManager.LoadScene(previousScene);
    }

    public void returningToMenu() {
        Debug.Log("PLAYER HAS GIVEN UP!");
        SceneManager.LoadScene("MainMenu");
    }
}
