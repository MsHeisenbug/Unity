using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	// Use this for initialization
	//works when game first runs
	int max, min, guess;

	void Start () {
		StartGame();
	}

	void StartGame () {
		max = 1000;
		min = 1;
		guess = 500;

		print("==========================================");
		print("Welcome to Number Wizard");
		print("Pick a number in your head but DON'T tell me");

		print("The highest number you can pick is " + max);
		print("The lowest number you can pick is " + min);

		print("Is the number lower or higher than " + guess + "?");
		print("Up = higher, Down = lower, return = equal");

		max = max + 1;
	}

	// Update is called once per frame
	void Update ()
	{
		//else if ważne przy rozróżnieniu klawiszy w przypadku jednoczesnego wciśnięcia kilku klawiszy
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			min = guess;
			NextGuess ();
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			max = guess;
			NextGuess ();
		} else if (Input.GetKeyDown (KeyCode.Return)) {
			print ("I won!");
			StartGame();
		}
	}

	void NextGuess () {
		guess = (max + min) / 2;
		print ("Higher or lower than " + guess + "?");
		print("Up = higher, Down = lower, return = equal");
	}
}
