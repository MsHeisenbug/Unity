using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float speed = 4.0f;
    private float h = 5.0f;
    private Rigidbody2D birdRB;
    private GameObject endText;
    private GameObject restartButton;
    private bool alive;

    private Animator animator;

    // Use this for initialization
    void Start () {
        birdRB = GetComponent<Rigidbody2D>();
        endText = GameObject.FindGameObjectWithTag("Finish");
        endText.active = false;
        restartButton = GameObject.FindGameObjectWithTag("Respawn");
        restartButton.active = false;
        alive = true;
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        birdRB.velocity = new Vector2(speed, birdRB.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && alive == true)
            birdRB.velocity = new Vector2(birdRB.velocity.x, birdRB.velocity.y + h);

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        birdRB.freezeRotation = true;
        if (collision.gameObject.name.Contains("Grass")) {
            alive = false;
            speed = 0.0f;
            endText.active = true;
            restartButton.active = true;
            animator.enabled = false;
            
        }
    }

}
