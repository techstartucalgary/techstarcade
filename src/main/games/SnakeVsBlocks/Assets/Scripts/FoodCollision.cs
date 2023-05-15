using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollision : MonoBehaviour
{
    GameObject snakeHead;
    Rigidbody2D rb;
    [SerializeField] GameObject foodText;
    GameObject myText;
    private int foodValue;
    
    public int FoodValue {
        get {
            return foodValue;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        snakeHead = GameObject.Find("SnakeHead");
        rb = gameObject.GetComponent<Rigidbody2D>();
        myText = Instantiate(foodText, transform.position, Quaternion.identity);
        int runTime = (int)(Time.time - snakeHead.GetComponent<SnakeCollisions>().startTime)/30;
        if (runTime > 15)
            runTime = 15;
        foodValue = (int)UnityEngine.Random.Range(1.1f, 5.9f + runTime);
        myText.GetComponentInChildren<TextMesh>().text = foodValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (snakeHead.GetComponent<SnakeCollisions>().inBlockCollision == true){
            rb.Sleep();
        }
        else {
            rb.WakeUp();
        }
        if (transform.position.y < -6.0f){
            Destroy(gameObject);
            Destroy(myText);
        }
        else {
            myText.transform.position = transform.position;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
        Destroy(myText);
    }
}
