using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Map map;
    public static LevelManager instance = null;
    private float totalScore;
    private string nextLevel;
    private int lastSceneToLoad;
    private float totalTime;

    //get and set for score
    public float getTotalScore()
    {
        return totalScore;
    }
    public void updateTotalScore(float levelScore) {
        totalScore = levelScore;
    }
    //get and set for time
    public void setTotalTime(float time) {
        totalTime += time;
    }
    public float getTotalTime() {
        return totalTime;
    }

    public LevelManager(float score) {
        totalScore = score;
    }
    
    public void loadNewLevel(string level)
    {
        nextLevel = level;
        updateTotalScore(map.getLevelScore());
        SceneManager.LoadScene(nextLevel);
        
    }

    public void loadCongratulationsScreen() {
        lastSceneToLoad = SceneManager.GetActiveScene().buildIndex + 2;
        SceneManager.LoadScene(lastSceneToLoad);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        nextLevel = SceneManager.GetActiveScene().name;
        map = GameObject.FindObjectOfType<Map>();
        if(nextLevel == "Level1") {
            totalScore = 0;
        }
        if (map != null)
        {
            map.addLevelScore(totalScore);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nextLevel != SceneManager.GetActiveScene().name)
        {
            nextLevel = SceneManager.GetActiveScene().name;
            map = GameObject.FindObjectOfType<Map>();
            if (map != null)
            {
                map.addLevelScore(totalScore);
            }

        }
        else if (SceneManager.GetActiveScene().name == "MainMenu") {
            Destroy(this.gameObject);
        }

        
    }

    


}
