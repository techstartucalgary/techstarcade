using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalaxBehaviour : MonoBehaviour
{
    //TODO
        // stalax sprites
    public PlayerController playerInfo;
    private Transform _stalax;
    private float _speed;
    private bool _scoreAdded;
    public float playerScore;
    void Start()
    {
        _stalax = gameObject.GetComponent<Transform>();
        playerScore = playerInfo.score;
        _speed = playerScore*0.5f + 5;
        _scoreAdded = false;
    }
    void Update()
    {
        _stalax.transform.position += Vector3.left * _speed * Time.deltaTime;

        if (_stalax.transform.position.x <= 0 && !_scoreAdded) {
            _scoreAdded = true;
            playerInfo.scoreChange();
            playerScore = playerInfo.score;
        }

        if (_stalax.transform.position.x <= -10) {
            restartStalax();
        }
    }
    void restartStalax() {
        _stalax.transform.position = new Vector3(17 + 0.5f*_speed, 0.15f+(Random.value * 4),0);
        _speed = playerScore*0.15f + 5;
        _scoreAdded = false;
    }
}
