using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   

    // TODO 
        // balance game with linear drag and jump and stalax gaps
    private Rigidbody2D player;

    public ScoreKeeper scoreKeeper;
    private float _jumpForce;
    private float _moveVertical;
    public bool isGameOver;
    private float _score;

    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        player.freezeRotation = true;
        _jumpForce = 3;
        isGameOver = false;
        player.constraints = RigidbodyConstraints2D.FreezePositionY;
        Invoke("unFreeze", 0.5f);
    }

    void Update()
    {
        _moveVertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKey("x") && isGameOver) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
        }
    }

    void FixedUpdate()
    {
        if (_moveVertical > 0.1f) {  // add a down movements for downward boosts
            player.AddForce(new Vector2(0f, _moveVertical * _jumpForce), ForceMode2D.Impulse);
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "GroundCeil") {

        } else if(collision.gameObject.tag == "Stalagmite") {
            Debug.Log(scoreKeeper.playerScore);
            Time.timeScale = 0;
            isGameOver = true;
        }
    }

    void unFreeze() {
        player.constraints = RigidbodyConstraints2D.None;
    }
}


