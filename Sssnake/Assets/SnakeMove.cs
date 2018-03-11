using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SnakeMove : MonoBehaviour {
    Vector2 cur = Vector2.right;
    List<Transform> body = new List<Transform>();
    bool ate = false;
    public GameObject tailPrefab;
    Rigidbody2D rb;
    float speed = 0.05f;
    bool horizontal = false;
    bool vertical = false;
    public GameObject gameOver;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Move", 0.3f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            vertical = true;
            horizontal = false;
            cur = Vector2.up;
        } else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            vertical = true;
            horizontal = false;
            cur = Vector2.down;
        } else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            cur = Vector2.left;
            vertical = false;
            horizontal = true;
        } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            cur = Vector2.right;
            vertical = false;
            horizontal = true;
        }

	}

    void Move() {
        Vector2 pos = transform.position;     //current position of head

        transform.Translate(cur);

        if(ate == true) {
            GameObject newGO = (GameObject)Instantiate(tailPrefab, pos, Quaternion.identity);
            body.Insert(0, newGO.transform);
            //Debug.Log("speed: " + rb.velocity);
            //rb.AddForce(speed*rb.velocity);
            ate = false;
        } else if (body.Count > 0) {
            body.Last().position = pos;
            body.Insert(0, body.Last());    //tail is now behind head
            body.RemoveAt(body.Count - 1);
        }     
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.name.StartsWith("Food")) {
            ate = true;
            Destroy(collision.gameObject);
        } else {
            gameOver.SetActive(true);
        }
    }
}
