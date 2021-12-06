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

    public void IncreaseDifficulty(int damageBoost, float speedBoost)
    {
        enemyDamage = baseEnemyDamage + damageBoost;
        enemySpeed = baseEnemySpeed + speedBoost;
    }

}