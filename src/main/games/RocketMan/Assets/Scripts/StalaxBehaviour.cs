using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalaxBehaviour : MonoBehaviour
{
    //TODO
        // stalax sprites
    public PlayerController playerInfo;
    private GameObject GroundCeil;
    private GameObject Background; 
    private Transform _stalax;
    private float _speed;
    private bool _scoreAdded;
    public float playerScore;
    void Start()
    {
        Background = GameObject.FindGameObjectWithTag("Background");
        GroundCeil = GameObject.FindGameObjectWithTag("GroundCeil");
        _stalax = gameObject.GetComponent<Transform>();
        playerScore = playerInfo.score;
        _speed = playerScore*0.5f + 5;
        _scoreAdded = false;
    }
    void Update()
    {
        _stalax.transform.position += Vector3.left * _speed * Time.deltaTime;
        GroundCeil.transform.position += Vector3.left * _speed * Time.deltaTime *0.25f;
        Background.transform.position += Vector3.left * _speed * Time.deltaTime * 0.1f;

        if (_stalax.transform.position.x <= 0 && !_scoreAdded) {
            _scoreAdded = true;
            playerInfo.scoreChange();
            playerScore = playerInfo.score;
        }

        if (GroundCeil.transform.position.x <= -100) {
            Background.transform.position = new Vector3(41, -1);
            GroundCeil.transform.position = new Vector3(0, 0);            
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
