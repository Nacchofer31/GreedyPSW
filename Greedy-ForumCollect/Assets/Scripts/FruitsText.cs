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
    
    // Start is called before the first frame update
    void Start()
    {
        GetLevelText();
        FruitsToString();
    }

    // Update is called once per frame
    void Update()
    {
        FruitsToString();
        if (numberOfFruits == 0)
        {
            NextLevel();
        }
    }

    public void FruitConsumed()
    {
        numberOfFruits--;
    }

    private void FruitsToString()
    {
        fruitsText.text = "FRUITS = " + numberOfFruits;
    }

    private void GetLevelText() {

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

    private void NextLevel() {
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

            map.GetNextlevel(nextScene);
        }
        else
        {
            nextScene = "LevelPassed";
            map.loadCongratulationsScreen();
        }
      }


}
