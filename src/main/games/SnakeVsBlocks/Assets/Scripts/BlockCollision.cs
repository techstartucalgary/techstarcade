using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    GameObject snakeHead;
    Rigidbody2D rb;
    [SerializeField] GameObject blockText;
    GameObject myText;
    public int blockValue;
    private bool myCollision = false;

    int snakeHealth;

    void Start()
    {
        snakeHead = GameObject.Find("SnakeHead");
        rb = gameObject.GetComponent<Rigidbody2D>();
        myText = Instantiate(blockText, transform.position, Quaternion.identity);
        int runTime = (int)(Time.time - snakeHead.GetComponent<SnakeCollisions>().startTime)/10;
        if (runTime > 26)
            runTime = 26;
        blockValue = (int)UnityEngine.Random.Range(1.1f, 5.9f + runTime);
        gameObject.GetComponent<Renderer>().material.color = new Color (243f/255f, (260 - blockValue*10)/255f, 22/255f, 1);
        myText.GetComponentInChildren<TextMesh>().text = blockValue.ToString();
        snakeHealth = snakeHead.GetComponent<SnakeCollisions>().PlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (blockValue == 0){
            Destroy(myText);
            Destroy(gameObject);
        }
        myText.GetComponentInChildren<TextMesh>().text = blockValue.ToString();
        if (snakeHead.GetComponent<SnakeCollisions>().inBlockCollision == true){
            if (myCollision && snakeHead.GetComponent<SnakeCollisions>().PlayerHealth != snakeHealth) {
                blockValue--;
                StartCoroutine(waiter());
            }
            rb.Sleep();
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else {
            rb.WakeUp();
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        snakeHealth = snakeHead.GetComponent<SnakeCollisions>().PlayerHealth;
        myText.transform.position = transform.position;

        if (transform.position.y < -6.0f){
            Destroy(myText);
            Destroy(gameObject);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "SnakeHead")
            myCollision = true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "SnakeHead")
            myCollision = false;
    }

    IEnumerator waiter(){
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Renderer>().material.color = new Color (243f/255f, (260 - blockValue*10)/255f, 22/255f, 1);
    }
}
