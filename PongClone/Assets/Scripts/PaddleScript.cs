using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {
    
    public bool isPlayerTwo;
    public float speed = 0.2f;       
    Transform myTransform;
    int direction = 0; // 0 - still, 1 - up, -1 - down
    float previousPosY;
    public GameManagerScript gamMan;

    // Use this for initialization
    void Start() {
        myTransform = transform;
    }

    // FixedUpdate is called once per physics tick/frame
    void FixedUpdate() {
        if (isPlayerTwo) {
            if (Input.GetKey("w"))
                MoveUp();
            else if (Input.GetKey("s"))
                MoveDown();
        } else {
            if (Input.GetKey(KeyCode.UpArrow))
                MoveUp();
            else if (Input.GetKey(KeyCode.DownArrow))
                MoveDown();
        }

        if (previousPosY > myTransform.position.y)
            direction = -1;
        else if (previousPosY < myTransform.position.y)
            direction = 1;
        else
            direction = 0;
    }

    //runs at the end of each frame
    void LateUpdate() {
        previousPosY = myTransform.position.y;
    }

    void MoveUp() {
        myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y + speed);
    }

    void MoveDown() {
        myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y - speed);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        gamMan.PlaySound(gamMan.playerHit);
    }
    void OnCollisionExit2D(Collision2D other) {
        float adjust = 5 * direction;
        other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x, other.rigidbody.velocity.y + adjust);
    }
}
