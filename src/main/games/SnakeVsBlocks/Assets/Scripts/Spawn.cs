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
    [SerializeField] GameObject blocksWall;

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

        if (timetillNextBlocks <= 0){
            SpawnItems();
            timetillNextBlocks = (int)UnityEngine.Random.Range(4.1f, 5.9f)*(blockScale)/2.0f; //*speed*amountOfBlockLinesWe want to skip
        }

    }

    void SpawnInitialItems()
    {
        int randomNumber = (int)UnityEngine.Random.Range(1.01f, 15.99f);
        for (int i = 1; i < 6; i++){
            if (randomNumber - i <= 0){
                randomNumber = i;
                break;
            }
            else
                randomNumber -= i;
        }

        for (int i = 0; i < randomNumber; i++){
            int p = (int)UnityEngine.Random.Range(0.01f, positions.Length-0.01f);
            Instantiate(blocks, new Vector2(positions[p], 8.5f), Quaternion.identity);
            positions = Array.FindAll(positions, j => j != positions[p]).ToArray();
        }
        Vector2 foodVector = new Vector2((2.0f - (int)UnityEngine.Random.Range(0.01f, 4.49f))*(blockScale), 5.5f);
        Instantiate(food, foodVector, Quaternion.identity);
        timetillNextBlocks = (int)UnityEngine.Random.Range(5.1f, 6.9f)*(blockScale)/2.0f; //*speed*amountOfBlockLinesWe want to skip
        positions = new[] {-3.0f, -1.5f, 0.0f, 1.5f, 3.0f};
        for (int i = 0; i < 4; i++){
            if (UnityEngine.Random.Range(0.01f, 3.0f) < 1.0f){
                Instantiate(blocksWall, new Vector2(positions[i] + 0.75f, 7.0f), Quaternion.identity);
                if (UnityEngine.Random.Range(0.01f, 2.0f) < 1.0f){
                    Instantiate(blocksWall, new Vector2(positions[i] + 0.75f, 5.5f), Quaternion.identity);
                }
            }
        }

    }

    void SpawnItems()
    {
        int randomNumber = (int)UnityEngine.Random.Range(1.01f, 15.99f);
        for (int i = 1; i < 6; i++){
            if (randomNumber - i <= 0){
                randomNumber = i;
                break;
            }
            else
                randomNumber -= i;
        }

        for (int i = 0; i < randomNumber; i++){
            int p = (int)UnityEngine.Random.Range(0.01f, positions.Length-0.01f);
            Instantiate(blocks, new Vector2(positions[p], 8.5f), Quaternion.identity);
            positions = Array.FindAll(positions, j => j != positions[p]).ToArray();
        }
        positions = new[] {-3.0f, -1.5f, 0.0f, 1.5f, 3.0f};
        for (int i = (int)UnityEngine.Random.Range(0.01f, 1.5f); i < 2; i++){
            int p = (int)UnityEngine.Random.Range(0.01f, positions.Length-0.01f);
            Vector2 foodVector = new Vector2(positions[p], (8.5f - (int)UnityEngine.Random.Range(1.1f, 2.9f)*blockScale));
            Instantiate(food, foodVector, Quaternion.identity);
            positions = Array.FindAll(positions, j => j != positions[p]).ToArray();
        }
        positions = new[] {-3.0f, -1.5f, 0.0f, 1.5f, 3.0f};
        for (int i = 0; i < 4; i++){
            if (UnityEngine.Random.Range(0.01f, 3.0f) < 1.0f){
                Instantiate(blocksWall, new Vector2(positions[i] + 0.75f, 7.0f), Quaternion.identity);
                if (UnityEngine.Random.Range(0.01f, 2.0f) < 1.0f){
                    Instantiate(blocksWall, new Vector2(positions[i] + 0.75f, 5.5f), Quaternion.identity);
                }
            }
        }

    }
}