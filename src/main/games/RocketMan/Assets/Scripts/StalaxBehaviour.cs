using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalaxBehaviour : MonoBehaviour
{
    //TODO
        // stalax sprites
    public PlayerController playerInfo;
    private Transform stalax;
    private float speed;
    public float playerScore;
    private bool scoreAdded;
    void Start()
    {
        stalax = gameObject.GetComponent<Transform>();
        playerScore = playerInfo.score;
        speed = playerScore*0.5f + 5;
        scoreAdded = false;
    }
    void Update()
    {
        stalax.transform.position += Vector3.left * speed * Time.deltaTime;

        if (stalax.transform.position.x <= 0 && !scoreAdded) {
            scoreAdded = true;
            playerInfo.scoreChange();
            playerScore = playerInfo.score;
        }

        if (stalax.transform.position.x <= -10) {
            restartStalax();
        }
    }
    void restartStalax() {
        stalax.transform.position = new Vector3(17 + 0.5f*speed, 0.15f+(Random.value * 4),0);
        speed = playerScore*0.15f + 5;
        scoreAdded = false;
    }
}
