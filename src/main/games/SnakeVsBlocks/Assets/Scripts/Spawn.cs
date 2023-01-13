using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    float blockScale = 1.5f;
    [SerializeField] GameObject blocks;
    [SerializeField] GameObject food;
    float timetillNextBlocks = 0.0f;
    float[] blockPositions = []
    // Start is called before the first frame update
    void Start()
    {
        SpawnInitialItems();
    }

    // Update is called once per frame
    void Update()
    {
        //Need to get food in before block line
        timetillNextBlocks -= Time.deltaTime;
        //Time till next blocks
        //If time till next block - blockLength*speed (modular, 3 line, 2 line, 1 line) & odds it produces food
            //produce food or foods in random x location
        //If time till next blocks
        print(timetillNextBlocks);
        if (timetillNextBlocks <= 0){
            SpawnItems();
            timetillNextBlocks = (int)Random.Range(4.1f, 5.9f)*(blockScale); //*speed*amountOfBlockLinesWe want to skip
            //produce random amount of block in random spots
            //set time for next blocks    
        }

    }

    void SpawnInitialItems()
    {
        for (int i = (int)Random.Range(0.0f, 3.9f); i < 4; i++){
            Instantiate(blocks, new Vector2((2.0f - i)*(blockScale), 8.5f), Quaternion.identity);
        }
        Instantiate(food, new Vector2((2.0f - (int)Random.Range(0.0f, 4.49f))*(blockScale), 5.5f), Quaternion.identity);
        timetillNextBlocks = (int)Random.Range(4.1f, 5.9f)*(blockScale); //*speed*amountOfBlockLinesWe want to skip
    }

    void SpawnItems()
    {
        for (int i = (int)Random.Range(0.0f, 3.9f); i < 4; i++){
            Instantiate(blocks, new Vector2((2.0f - i)*(blockScale), 8.5f), Quaternion.identity);
        }
        for (int i = (int)Random.Range(0.0f, 2.5f); i < 3; i++){
            Instantiate(food, new Vector2((2.0f - (int)Random.Range(0.0f, 4.49f))*(blockScale), (8.5f - (int)Random.Range(1.1f, 2.9f)*blockScale)), Quaternion.identity);
        }
    }
}