using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Spawn : MonoBehaviour
{
    GameObject snakeHead;
    float blockScale = 1.5f;
    [SerializeField] GameObject blocks;
    [SerializeField] GameObject food;
    float timetillNextBlocks = 0.0f;
    float[] positions = {-3.0f, -1.5f, 0.0f, 1.5f, 3.0f};
    // Start is called before the first frame update
    void Start()
    {
        snakeHead = GameObject.Find("SnakeHead");
        SpawnInitialItems();
    }

    // Update is called once per frame
    void Update()
    {
        //Need to get food in before block line
        if (snakeHead.GetComponent<SnakeCollisions>().inBlockCollision == false){
            timetillNextBlocks -= Time.deltaTime;
        }

        //Debug.Log(timetillNextBlocks);

        //Time till next blocks
        //If time till next block - blockLength*speed (modular, 3 line, 2 line, 1 line) & odds it produces food
            //produce food or foods in random x location
        //If time till next blocks
        if (timetillNextBlocks <= 0){
            SpawnItems();
            timetillNextBlocks = (int)UnityEngine.Random.Range(4.1f, 5.9f)*(blockScale)/2.0f; //*speed*amountOfBlockLinesWe want to skip
            //produce random amount of block in random spots
            //set time for next blocks    
        }

    }

    void SpawnInitialItems()
    {
        for (int i = (int)UnityEngine.Random.Range(0.0f, 3.99f); i < 4; i++){
            int p = (int)UnityEngine.Random.Range(0.0f, positions.Length-0.01f);
            Instantiate(blocks, new Vector2(positions[p], 8.5f), Quaternion.identity);
            positions = Array.FindAll(positions, i => i != positions[p]).ToArray();
        }
        Vector2 foodVector = new Vector2((2.0f - (int)UnityEngine.Random.Range(0.0f, 4.49f))*(blockScale), 5.5f);
        Instantiate(food, foodVector, Quaternion.identity);
        timetillNextBlocks = (int)UnityEngine.Random.Range(5.1f, 6.9f)*(blockScale)/2.0f; //*speed*amountOfBlockLinesWe want to skip
        positions = new[] {-3.0f, -1.5f, 0.0f, 1.5f, 3.0f};
    }

    void SpawnItems()
    {
        for (int i = (int)UnityEngine.Random.Range(0.0f, 3.9f); i < 4; i++){
            int p = (int)UnityEngine.Random.Range(0.0f, positions.Length-0.01f);
            Instantiate(blocks, new Vector2(positions[p], 8.5f), Quaternion.identity);
            positions = Array.FindAll(positions, i => i != positions[p]).ToArray();
        }
        positions = new[] {-3.0f, -1.5f, 0.0f, 1.5f, 3.0f};
        for (int i = (int)UnityEngine.Random.Range(0.0f, 2.5f); i < 3; i++){
            int p = (int)UnityEngine.Random.Range(0.0f, positions.Length-0.01f);
            Vector2 foodVector = new Vector2(positions[p], (8.5f - (int)UnityEngine.Random.Range(1.1f, 2.9f)*blockScale));
            Instantiate(food, foodVector, Quaternion.identity);
            positions = Array.FindAll(positions, i => i != positions[p]).ToArray();
        }
        positions = new[] {-3.0f, -1.5f, 0.0f, 1.5f, 3.0f};
    }
}