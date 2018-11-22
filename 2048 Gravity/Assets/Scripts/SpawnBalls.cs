﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    public GameObject ballTemplate;
    public GameObject ballContainer;
    public float spawnFrequency = 1;
    public float deathPlane = -50;

    GameObject[] ballSpawns;


    // Use this for initialization
    void Start()
    {
        ballSpawns = gameObject.GetChildObjects();
        Invoke("SpawnBall", spawnFrequency);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < deathPlane)
        {
            Destroy(gameObject);
        }
    }

    void SpawnBall()
    {
        GameObject chosenSpawn = SelectSpawn();
        GameObject newBall = Instantiate(ballTemplate);
        newBall.transform.position = chosenSpawn.transform.position;
        newBall.transform.parent = ballContainer.transform;

        //chain this into the next ball spawning
        Invoke("SpawnBall", spawnFrequency);
    }

    GameObject SelectSpawn()
    {
        Debug.Assert(ballSpawns != null);
        Debug.Assert(ballSpawns.Length > 0);

        float rand01 = Random.value;
        float randRange = rand01 * ballSpawns.Length;
        int index = Mathf.FloorToInt(randRange);
        return ballSpawns[index];
    }
}
