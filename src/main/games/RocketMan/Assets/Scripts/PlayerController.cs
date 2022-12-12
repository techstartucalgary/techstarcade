using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   

    // TODO 
        // start scene with 0 y velocity
            // hardcode zero start velocity or have a new game scene
        //disable controls after hitting an obstacle
    private Rigidbody2D player;

    private float jumpForce;
    private float moveVertical;
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "GroundCeil") {
            Debug.Log("You've hit ground!");
        } else if(collision.gameObject.tag == "Stalagmite") {
            Debug.Log("Sitting on a stalagmite");
            FindObjectOfType<GameState>().GameOver();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        player.freezeRotation = true;
        jumpForce = 3;
    }

    // Update is called once per frame
    void Update()
    {
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (moveVertical > 0.1f) {  // add a down movements for downward boosts
            player.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }
}


