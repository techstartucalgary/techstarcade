using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalaxBehaviour : MonoBehaviour
{
    private GameObject stalaxPair;
    private float speed;
    private Transform stalax;
    void Start()
    {
        stalaxPair = this.gameObject;
        stalax = gameObject.GetComponent<Transform>();
        speed = 4f;
        Debug.Log(stalaxPair);
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
        Destroy(stalaxPair);
    }
}
