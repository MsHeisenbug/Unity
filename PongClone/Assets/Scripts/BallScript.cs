using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    public float forceValue = 4.5f;
    Rigidbody2D myBody;
	// Use this for initialization
	void Start () {
        
        myBody = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(0, 0);
        
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reset() {
        Start();
        myBody.velocity = Vector2.zero;
        myBody.AddForce(new Vector2(forceValue * 50, 50));
        forceValue = forceValue * (-1);

    }

    public void Stop() {
        myBody.velocity = Vector2.zero;
    }
}
