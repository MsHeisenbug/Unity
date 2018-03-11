using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

    public GameObject food;
    public Transform top, down, left, right;
    public GameObject gameOver;
    // Use this for initialization
    void Start() {
        InvokeRepeating("Spawn", 1, 2);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }

    void Spawn() {
        float x, y;

        x = Random.Range(left.position.x, right.position.x);

        y = Random.Range(down.position.y, top.position.y);

        Instantiate(food, new Vector2(x, y), Quaternion.identity);

                                        

    }
}
