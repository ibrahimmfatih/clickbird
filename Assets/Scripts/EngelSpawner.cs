using System;
using UnityEngine;

public class EngelSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float maxTime;
    float timer;
    public float maxY;
    public float minY;
    public float randomY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //   InstantiateObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMenager.gameOver ==false && GameMenager.gameStarted == true)
        {

            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                randomY = UnityEngine.Random.Range(minY, maxY);
                InstantiateObstacle();
                timer = 0;
            }
        }
       
    }
        public void InstantiateObstacle()
        {
            GameObject newObstacle = Instantiate(obstacle);
            newObstacle.transform.position = new Vector2(transform.position.x, randomY);
        }
    }
