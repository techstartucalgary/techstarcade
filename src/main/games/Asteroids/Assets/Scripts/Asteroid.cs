using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject asteroid;
    public LevelManager Lv;

    public Vector3 dir;
    public int size = 3;
    public float velocity;
    void Start()
    {
        velocity = 0.01f + (0.001f * (Lv.level));
        if (velocity > 0.025f) velocity = 0.025f;
        velocity /= size;
    }

    void Update()
    {
        transform.Translate(new Vector3(velocity * dir.x, velocity * dir.y, 0), Space.World);
        if (transform.position.x > 30 || transform.position.x < -30){Destroy(gameObject);}
        if (transform.position.y > 30 || transform.position.y < -30){Destroy(gameObject);}

        if (size == 0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet"){
            BreakApart();
            Lv.score += (size * 100);
            Destroy(gameObject);
        }
    }

    private void spawnAsteroids(int quantity){
        float angleIncrement  = 360 / quantity;
        float curAngle = 0;
        for (int i = 0; i < quantity; i++){
            float angle = UnityEngine.Random.Range(curAngle, curAngle + angleIncrement);
            curAngle += angleIncrement;
            Vector3 direction = new Vector3((float)Math.Cos((angle) * Math.PI / 180), (float)Math.Sin((angle) * Math.PI / 180), 0);

            Vector3 spawnPoint = new Vector3(transform.position.x + UnityEngine.Random.Range(-0.07f, 0.07f), transform.position.y + UnityEngine.Random.Range(-0.07f, 0.07f), 0);

            GameObject newAsteroid = Instantiate(asteroid, spawnPoint, new Quaternion());
            Asteroid ast = newAsteroid.GetComponent<Asteroid>();
            Transform t = newAsteroid.GetComponent<Transform>();
            ast.size = this.size - 1;
            t.localScale = new Vector3(ast.size, ast.size, 0);
            ast.dir = direction;
        }
    }
    
    private void BreakApart(){
        if (size == 3){
            spawnAsteroids(UnityEngine.Random.Range(2,5));
        }

        if (size == 2){
            spawnAsteroids(UnityEngine.Random.Range(2,4));
        }

        if (size == 1){Destroy(gameObject);}
    }
}
