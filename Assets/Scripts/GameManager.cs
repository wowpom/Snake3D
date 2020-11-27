using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject foodPrefabs;
    public float timeBetweenSpawn;
    private SnakeScript snakeScript;

    void Start()
    {
        snakeScript = GameObject.Find("Snake").GetComponent<SnakeScript>();
        InvokeRepeating("SpawnFood", timeBetweenSpawn, timeBetweenSpawn);
    }
    
    void SpawnFood()
    {
        if(snakeScript.isGame == true) 
        { 
            GameObject food = Instantiate(foodPrefabs, RandomSpawn(), gameObject.transform.rotation);
        }
    }

    private Vector3 RandomSpawn()
    {
        Vector3 randomPos = new Vector3(Random.Range(3, 38), 0.5f, Random.Range(-17, 17));
        return randomPos;
    }
}
