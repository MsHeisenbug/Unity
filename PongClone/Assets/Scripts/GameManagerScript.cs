using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
    int player1Score, player2Score;
    public BallScript gameBall;
    public Text score;
    public AudioClip goalScored;
    public AudioClip playerHit;
    AudioSource audSource;
    public GameObject endGameScreen;

    // Use this for initialization
    void Start () {
        audSource = GetComponent<AudioSource>();
        StartNewGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoalScored(int playerNumber) {
        PlaySound(goalScored);
        if (playerNumber == 1)
            player1Score++;
        else if (playerNumber == 2)
            player2Score++;

        if (player1Score == 3)
            GameOver(1);
        else if (player2Score == 3)
            GameOver(2);

        UpdateScore();
    }

    void GameOver(int winner) {
        
        gameBall.Stop();
        endGameScreen.SetActive(true);
        //StartNewGame();
    }

    void UpdateScore() {
        score.text = "Player One " + player1Score.ToString() + " - " + player2Score.ToString() + " Player Two";

    }

    public void PlaySound(AudioClip sound) {
        audSource.clip = sound;
        audSource.Play();

    }

    public void StartNewGame() {
        player1Score = 0;
        player2Score = 0;
        UpdateScore();
        endGameScreen.SetActive(false);
        gameBall.Reset();
    }
}
