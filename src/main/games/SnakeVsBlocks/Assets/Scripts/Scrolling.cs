using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject scrollItem;
    // Start is called before the first frame update
    void Start()
    {
        scrollItem = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        scrollItem.transform.position -= new Vector3(0, speed*Time.deltaTime, 0);
    }
}
