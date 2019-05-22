using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public LevelManager LevelManager;

    public void PlayGame() {
        SceneManager.LoadScene("Level1");
        CaloriesScript.caloriesValue = 0;
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
        LevelManager.SetTotalScore(0);
    }
    public void QuitGame() {
        Debug.Log("QUIT!");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();

   }
}
