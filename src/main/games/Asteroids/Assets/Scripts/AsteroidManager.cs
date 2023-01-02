using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject asteroid;
    [SerializeField] GameObject levelManager;
    private LevelManager Lv;
    private Vector3[] spawnPoints;

    public float radius;
    public float spawnDelay;
    private bool ifCoroutine;

    void Start()
    {
        spawnPoints = new Vector3[] {
            new Vector3(-16, 10, 0), 
            new Vector3(-10.7f, 10, 0), 
            new Vector3(-5.3f, 10, 0),
            new Vector3(0, 10, 0), 
            new Vector3(5.3f, 10, 0),
            new Vector3(10.7f, 10, 0), 
            new Vector3(16, 10, 0),
            new Vector3(16, 4, 0), 
            new Vector3(16, -4, 0), 
            new Vector3(16, -10, 0),            
            new Vector3(16, -10, 0), 
            new Vector3(10.7f, -10, 0), 
            new Vector3(5.3f, -10, 0),
            new Vector3(-0, -10, 0), 
            new Vector3(-5.3f, -10, 0),
            new Vector3(-10.7f, -10, 0), 
            new Vector3(-16, -10, 0),
            new Vector3(-16, -4, 0), 
            new Vector3(-16, 4, 0), 
            new Vector3(-16, 10, 0)  
        };
        spawnDelay = 5f;
        ifCoroutine = false;


        Lv = levelManager.GetComponent<LevelManager>();

    }

    private Vector3 asteroidSpawnDir(Vector3 spawnPoint){
        float angle = UnityEngine.Random.Range(0, 360);
        Vector3 circlePoint = new Vector3((float)Math.Cos((angle) * Math.PI / 180) * radius, (float)Math.Sin((angle) * Math.PI / 180) * radius, 0);
        Vector3 dir = circlePoint - spawnPoint;
        dir.Normalize();
        return dir;
    }

    IEnumerator spawnAsteroid(Vector3 spawnPoint){
        ifCoroutine = true;
        Vector3 dir = asteroidSpawnDir(spawnPoint);
        GameObject newAsteroid = Instantiate(asteroid, spawnPoint, new Quaternion());
        Asteroid ast = newAsteroid.GetComponent<Asteroid>();
        Transform t = newAsteroid.GetComponent<Transform>();
        ast.size = UnityEngine.Random.Range(1, 4);
        t.localScale = new Vector3(ast.size, ast.size, 0);
        ast.dir = dir;
        ast.Lv = Lv;
        yield return new WaitForSeconds(spawnDelay);
        ifCoroutine = false;
    }

    void Update()
    {
        if (!ifCoroutine){
            Vector3 randSpawn = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
            StartCoroutine(spawnAsteroid(randSpawn));
        }
    }

}
