using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPointsHolder;


   /* public GameObject zombunny;
    public GameObject zombear;
    public GameObject hellephant;
    public GameObject nightmareZombunny;
    public GameObject nightmareZombear;
    public GameObject NightmareHellephant;
   */
    public GameObject[] enemysPrefabs;  // 0 - zombunny; 1 - zombear; 2 - hellephant; 3 - nightmareZombunny; 4 - nightmareZombear; 5 - nightmareHellephant 


    float zombunnySpawnTime = 3f;
    float zombearSpawnTime = 7f;
    float hellephantSpawnTime = 9f;
    float nightmareBunnySpawnTime = 8f;
    float nightmareBearSpawnTime = 10f;
    float nightmareHellSpawnTime = 13f;

    float[] enemysSpawnTime = { 3f, 7f, 10f, 10f, 13f, 17f };

    float timeToStartSpawnBunny = 0f;
    float timeToStartSpawnBear = 20f;
    float timeToStartSpawnHellephant = 37f;
    float timeToStartSpawnNightBunny = 30f;
    float timeToStartSpawnNightBear = 45f;
    float timeToStartSpawnNightHell = 60f;

    float[] timeStartToSpawnEnemys;

    float nextNZombunnySpawnTime = 0;
    float nextNZombearSpawnTime = 0;
    float nextHellephantSpawnTime = 0;
    float nextNightmareBunnySpawnTime = 0;
    float nextNightmareBearSpawnTime = 0;
    float nextNightmareHellSpawnTime = 0;

    float[] nextSpawnEnemysTime = {0,0,0,0,0,0};



    bool playerDied = false;

    Vector3[] spawnPoints;

    IEnumerator zombunnyCoroutine;
    IEnumerator zombearCoroutine;
    IEnumerator hellephantCoroutine;
    IEnumerator enemysCoroutine;


    private void Start()
    {

        PlayerStats.OnPlayerDeath += PlayerDied;

        spawnPoints = new Vector3[spawnPointsHolder.childCount];

        for(int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = spawnPointsHolder.GetChild(i).position;
        }


        timeStartToSpawnEnemys = new float[] {Time.time + timeToStartSpawnBunny, Time.time + timeToStartSpawnBear, Time.time + timeToStartSpawnHellephant, Time.time + timeToStartSpawnNightBunny, Time.time + timeToStartSpawnNightBear, Time.time + timeToStartSpawnNightHell};

        // zombunnyCoroutine = SpawnZombunny();
        // zombearCoroutine = SpawnZombear();
        // hellephantCoroutine = SpawnHellephant();
        enemysCoroutine = SpawnEnemys(enemysPrefabs, enemysSpawnTime, timeStartToSpawnEnemys, nextSpawnEnemysTime);




        //StartCoroutine(zombunnyCoroutine);
        // StartCoroutine(zombearCoroutine);
        //StartCoroutine(hellephantCoroutine);
        StartCoroutine(enemysCoroutine);


    }


    private void Update()
    {
        if(playerDied)
        {
            StopAllCoroutines();
        }
    }


    IEnumerator SpawnEnemys(GameObject[] enemys, float[] timeBetweenSpawns, float[] startSpawnTime, float[] nextSpawnTime)
    {
        int i;
        
        while (true)
        {
            for(i = 0; i < enemys.Length; i++)
            {
                if(Time.time >= startSpawnTime[i])
                {
                    if(Time.time >= nextSpawnTime[i])
                    {
                        nextSpawnTime[i] = Time.time + timeBetweenSpawns[i];
                        Instantiate(enemys[i], GetRandomSpawnPoint(), Quaternion.identity);
                    }
                }
            }

            yield return null;
        }


    }
/*
    IEnumerator SpawnZombunny()
    {
        while (true)
        {
            Instantiate(zombunny, GetRandomSpawnPoint(), Quaternion.identity);
            yield return new WaitForSeconds(zombunnySpawnTime);
        }

        
    }

    IEnumerator SpawnZombear()
    {
        while (true)
        {
            Instantiate(zombear, GetRandomSpawnPoint(), Quaternion.identity);
            yield return new WaitForSeconds(zombearSpawnTime);
        }


    }

    IEnumerator SpawnHellephant()
    {
        while (true)
        {
            Instantiate(hellephant, GetRandomSpawnPoint(), Quaternion.identity);
            yield return new WaitForSeconds(hellephantSpawnTime);
        }


    }

    */

    Vector3 GetRandomSpawnPoint()
    {
        Vector3 randomSpawnPoint;
        int aux = Random.Range(0, spawnPoints.Length);

        randomSpawnPoint = spawnPoints[aux];

        return randomSpawnPoint;
    }


    void PlayerDied()
    {
        playerDied = true;
    }


    private void OnDestroy()
    {
        PlayerStats.OnPlayerDeath -= PlayerDied;
    }

}
