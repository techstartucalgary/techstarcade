using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public int levelThershold = 1000, score, level = 1;
    [SerializeField] GameObject AsteroidManager;
    private AsteroidManager Am;
    void Start()
    {
        Am = AsteroidManager.GetComponent<AsteroidManager>();
    }


    void Update()
    {
        if (score >= levelThershold){
            level += 1;
            levelThershold += (1000 + (100 * (level - 1)));
            if (Am.spawnDelay > 0.5){
                Am.spawnDelay = (Mathf.Exp(-level) - (0.01f * Mathf.Pow(level, 2)) + 3);
            }
            else Am.spawnDelay = 0.5f;
        }
    }
}
