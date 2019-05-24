using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitsText : MonoBehaviour
{
    public Text fruitsText;
    public Map map;

    public Character_mov player;

    private string nextScene;
    private int numberOfFruits;
    /**
    public FruitsText() {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            numberOfFruits = 4;

        }
        else if (SceneManager.GetActiveScene().name == "Level2") {
            numberOfFruits = 8;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            numberOfFruits = 12;
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            numberOfFruits = 16;
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            numberOfFruits = 20;
        }
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        getLevelText();
        fruitsToString();
    }

    // Update is called once per frame
    void Update()
    {

        fruitsToString();
        if (numberOfFruits == 0) {
            nextLevel();
        }
    }



    public void fruitConsumed() {
        numberOfFruits--;
    }

    private void fruitsToString() {
        fruitsText.text = "FRUITS = " + numberOfFruits;
    }

    private void getLevelText() {

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            numberOfFruits = 4;

        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            numberOfFruits = 8;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            numberOfFruits = 12;
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            numberOfFruits = 16;
        }
        else if (SceneManager.GetActiveScene().name == "Level_5")
        {
            numberOfFruits = 20;
        }
    }

    private void nextLevel() {
        if (SceneManager.GetActiveScene().name != "Level_5")
        {

            if (SceneManager.GetActiveScene().name == "Level1")
            {
                nextScene = "Level2";

            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                nextScene = "Level3";
            }
            else if (SceneManager.GetActiveScene().name == "Level3")
            {
                nextScene = "Level4";
            }
            else if (SceneManager.GetActiveScene().name == "Level4")
            {
                nextScene = "Level_5";
            }

            map.getNextlevel(nextScene);
        }
        else {
            nextScene = "LevelPassed";
            map.loadCongratulationsScreen();
        }
      }


}
