using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalaxBehaviour : MonoBehaviour
{
    //TODO
        // manipulate speed based on player progress
    private GameObject stalaxPair;
    private float speed;
    private Transform stalax;
    void Start()
    {
        stalaxPair = this.gameObject;
        stalax = gameObject.GetComponent<Transform>();
        speed = 10f;
    }
    void Update()
    {
        stalax.transform.position += Vector3.left * speed * Time.deltaTime;
        if (stalax.transform.position.x <= -10) {
            destroyStalax();
        }
    }
    private void destroyStalax() {
        Debug.Log("AT THE END");
        stalax.transform.position = new Vector3(18, 0.5f+(Random.value * 4),0);
    }
}
