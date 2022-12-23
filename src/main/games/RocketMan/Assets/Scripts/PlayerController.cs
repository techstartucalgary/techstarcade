using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   

    // TODO 
        // start scene with 0 y velocity
            // hardcode zero start velocity or have a new game scene
        // balance game with linear drag and jump and stalax gaps
    private Rigidbody2D player;

    private float jumpForce;
    private float moveVertical;
    public bool isGameOver;
    public ScoreKeeper scoreKeeper;
    private float score;

    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        player.freezeRotation = true;
        jumpForce = 3;
        isGameOver = false;
    }

    void Update()
    {
        moveVertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKey("x") && isGameOver) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
        }
    }

    void FixedUpdate()
    {
        if (moveVertical > 0.1f) {  // add a down movements for downward boosts
            player.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "GroundCeil") {
            // Debug.Log("You've hit ground!");
        } else if(collision.gameObject.tag == "Stalagmite") {
            // Debug.Log("Sitting on a stalagmite");
            Time.timeScale = 0;
            isGameOver = true;
        }
    }
}


