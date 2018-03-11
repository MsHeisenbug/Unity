using UnityEngine;

public class GoalScript : MonoBehaviour {
    public int attackingPlayer;
    public GameManagerScript gameMan;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.name == "Ball") {
            gameMan.GoalScored(attackingPlayer);
           
        }
            
    }
}
