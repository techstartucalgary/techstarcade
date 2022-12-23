using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{   

    // TODO 
        // balance game with linear drag and jump and stalax gaps
    private Rigidbody2D player;

    private float _jumpForce;
    private float _moveVertical;
    public bool isGameOver;
    public float score;
    public Text scoreDisplay;

    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        _jumpForce = 3;
        isGameOver = false;
        score = 0;
        scoreDisplay.text = score.ToString();

        player.freezeRotation = true;
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
            Debug.Log(score);
            Time.timeScale = 0;
            isGameOver = true;
        }
    }

    void unFreeze() {
        player.constraints = RigidbodyConstraints2D.None;
    }

    public void scoreChange() {
        score++;
        scoreDisplay.text = score.ToString();
    }
}


