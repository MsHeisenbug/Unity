using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{


    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public LayerMask groundLayer;
    bool grounded = false;

    private bool doubleJumped;

    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer);
    }

    void Update() {
        if (grounded)
            doubleJumped = false;

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && grounded)
            Jump();

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !doubleJumped && !grounded) {
            Jump();
            doubleJumped = true;
        }


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

    }

    public void Jump() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    


}
