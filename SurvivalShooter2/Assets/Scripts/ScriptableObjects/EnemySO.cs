using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public new string name;
    public int enemyMaxHealth;
    public int enemyPoints;
    public AudioClip enemyDeathSound;

    public int enemyDamage;
    public float enemyAttackRadius;
    public float enemyAttackRate;
    public float enemySpeed;
    public float stopDistance;

    public float firstTimeToSpawn;
    public float timeToSpawn;

    public int baseEnemyDamage;
    public float baseEnemySpeed;
    public float basetimeToSpawn;

    public int enemyDamageBoost;
    public float enemySpeedBoost;
    public float enemyTimeToSpawnBoost;

    public int maxEnemyDamage;
    public float maxEnemySpeed;
    public float minTimeToSpawn;

    public float dropPickupPossibility;

    public void IncreaseDifficulty()
    {
        Debug.Log($"{name} increasing difficulty");

        enemyDamage = baseEnemyDamage + enemyDamageBoost;
        enemySpeed = baseEnemySpeed + enemySpeedBoost;
        timeToSpawn = basetimeToSpawn - enemyTimeToSpawnBoost;

        if (enemyDamage > maxEnemyDamage)
            enemyDamage = maxEnemyDamage;
        
        if (enemySpeed > maxEnemySpeed)
            enemySpeed = maxEnemySpeed;

        if (timeToSpawn < minTimeToSpawn)
            timeToSpawn = minTimeToSpawn;
        
    }

    public void ResetStats()
    {
        Debug.Log($"{name} reseting difficulty");
        enemyDamage = baseEnemyDamage;
        enemySpeed = baseEnemySpeed;
        timeToSpawn = basetimeToSpawn;
    }

}