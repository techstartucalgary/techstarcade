using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChild : MonoBehaviour
{
    [SerializeField] GameObject snakeChild;
    GameObject snakeHead;
    int childNumber;
    GameObject myChild;
    Vector3[] prevPosition = new Vector3[6];
    public Vector3[] PrevPosition {
        get {
            return prevPosition;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        snakeHead = GameObject.Find("SnakeHead");
        
        childNumber = snakeHead.GetComponent<SnakeCollisions>().numberOfChildren;

        if (childNumber == 1){
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
        else{
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (childNumber + 1 != snakeHead.GetComponent<SnakeCollisions>().PlayerHealth){
            snakeHead.GetComponent<SnakeCollisions>().numberOfChildren++;
            myChild = Instantiate(snakeChild, transform.position - new Vector3(0.0f, 0.35f, 0.0f), Quaternion.identity);
            myChild.transform.SetParent(transform);
        }

        prevPosition[0] = transform.position;
        prevPosition[1] = transform.position;
        prevPosition[2] = transform.position;
        prevPosition[3] = transform.position;
        //prevPosition[4] = transform.position;
        prevPosition[4] = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (childNumber == 1){
            transform.position = transform.parent.GetComponent<MoveSnake>().PrevPosition[0] - new Vector3(0.0f, 0.4f, 0.0f);
            //Debug.Log(transform.childCount);
        }
        else{
            transform.position = transform.parent.GetComponent<MoveChild>().PrevPosition[0] - new Vector3(0.0f, 0.35f, 0.0f);
        }
        //IMPROVEMENT TO BE DONE
        //If I want it smoother I should get take previous positions exponentially
        //i.e if I have 3 childs have the last one take 8 positions before, 2nd to last 4 positions before
        //and 3rd to last 2 positions before 

        prevPosition[0] = prevPosition[1];
        prevPosition[1] = prevPosition[2];
        prevPosition[2] = prevPosition[3];
        prevPosition[3] = prevPosition[4];
        //prevPosition[4] = prevPosition[5];
        prevPosition[4] = transform.position;

        //for the first child
        if (transform.childCount == 0 && snakeHead.GetComponent<SnakeCollisions>().PlayerHealth > childNumber + 1){
            //CODE IMPROVEMENT COULD BE DONE
            //These lines are repeated in the start function
            snakeHead.GetComponent<SnakeCollisions>().numberOfChildren++;
            myChild = Instantiate(snakeChild, transform.position - new Vector3(0.0f, 0.35f, 0.0f), Quaternion.identity);
            myChild.transform.SetParent(transform);
        }

        else if (snakeHead.GetComponent<SnakeCollisions>().PlayerHealth < childNumber + 1){
            Destroy(gameObject);
            snakeHead.GetComponent<SnakeCollisions>().numberOfChildren--;
        }
    }
}
