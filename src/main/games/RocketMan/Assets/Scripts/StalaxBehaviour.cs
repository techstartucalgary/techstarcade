using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalaxBehaviour : MonoBehaviour
{
    //TODO
        // manipulate speed based on player progress
    public PlayerController playerInfo;
    private Transform stalax;
    private float speed;
    public float playerScore;
    void Start()
    {
        stalax = gameObject.GetComponent<Transform>();
        playerScore = playerInfo.scoreKeeper.playerScore;
        speed = playerScore*0.5f + 5;
    }
    void Update()
    {
        stalax.transform.position += Vector3.left * speed * Time.deltaTime;
        if (stalax.transform.position.x <= -10) {
            destroyStalax();
        }
    }
    void destroyStalax() {
        stalax.transform.position = new Vector3(18, 0.5f+(Random.value * 4),0);
        playerInfo.scoreKeeper.scoreChange();
        playerScore = playerInfo.scoreKeeper.playerScore;
        speed = playerScore*0.5f + 5;
        
        Debug.Log(playerScore + " " + speed);
    }
}
