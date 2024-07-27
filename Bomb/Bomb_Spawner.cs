using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Spawner : MonoBehaviour
{
    public float rModel;
    public float rModule;
    public bool isSpawned;
    public Transform bombSpawner;
    //Moduel #1
    public GameObject bombPrefab1;
    public GameObject bombPrefab2;
    public GameObject bombPrefab3;
    //Moduel #2
    public GameObject bombPrefab4;
    public GameObject bombPrefab5;
    public GameObject bombPrefab6;
    //Moduel #3
    public GameObject bombPrefab7;
    public GameObject bombPrefab8;
    public GameObject bombPrefab9;
    void Start()
    {
        rModel = Random.Range(0f, 3f);
        rModule = Random.Range(0f, 3f);
        isSpawned = false;
    }
    void Update()
    {
        if (!isSpawned)
        {
            if(rModule <= 0.99f)
            {
                if(rModel <= 0.99f)
                {
                    GameObject Bomb = Instantiate(bombPrefab1, bombSpawner.position, bombSpawner.rotation);
                    isSpawned = true;
                }
                else if(rModel <= 1.99f)
                {
                    GameObject Bomb = Instantiate(bombPrefab2, bombSpawner.position, bombSpawner.rotation);
                    isSpawned = true;
                }
                else if((rModel <= 3f))
                {
                    GameObject Bomb = Instantiate(bombPrefab3, bombSpawner.position, bombSpawner.rotation);
                    isSpawned = true;
                }
            }
            else if(rModule <= 1.99f)
            {
                if(rModel <= 0.99f)
                {
                    GameObject Bomb = Instantiate(bombPrefab4, bombSpawner.position, bombSpawner.rotation);
                    isSpawned = true;
                }
                else if(rModel <= 1.99f)
                {
                    GameObject Bomb = Instantiate(bombPrefab5, bombSpawner.position, bombSpawner.rotation);
                    isSpawned = true;
                }
                else if((rModel <= 3f))
                {
                    GameObject Bomb = Instantiate(bombPrefab6, bombSpawner.position, bombSpawner.rotation);
                    isSpawned = true;
                }
            }
            else if (rModule <= 3f)
            {
                if(rModel <= 0.99f)
                {
                    GameObject Bomb = Instantiate(bombPrefab7, bombSpawner.position, bombSpawner.rotation);
                    isSpawned = true;
                }
                else if(rModel <= 1.99f)
                {
                    GameObject Bomb = Instantiate(bombPrefab8, bombSpawner.position, bombSpawner.rotation);
                    isSpawned = true;
                }
                else if((rModel <= 3f))
                {
                    GameObject Bomb = Instantiate(bombPrefab9, bombSpawner.position, bombSpawner.rotation);
                    isSpawned = true;
                }
            }
        }
    }
}
