using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour {

    public static int scoreVal = 0;
    public Text scoreTxt;
    public string levelToLoad;
    // Use this for initialization
    void Start () {
   
	}
	
	// Update is called once per frame
	void Update () {
        scoreTxt.text = "Points: " + scoreVal;      
    }
      
    public void restartLevel() {
        scoreVal = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
