using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CongratulationsScreen : MonoBehaviour
{

    public void finishGame() {
        //To be finished
        Debug.Log("Congratulations, you finished the game. Coming back to main menu...");
        //Save score...
        SceneManager.LoadScene("MainMenu");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
