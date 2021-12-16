using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave 
{
    public string waveName;
    public GameObject[] enemiesToSpawn;
    public float waveDuration;

    public Color waveLightColor;

    public void ApplyWaveEffects(bool apllyEnemyEffects)
    {
        Debug.Log("Applying wave effects");
        WaveManager.Instance.ChangeAmbientLight(waveLightColor);

        EnemySetup enemySetup;

        foreach (var enemy in enemiesToSpawn)
        {
            enemySetup = enemy.GetComponent<EnemySetup>();
            
            if (apllyEnemyEffects)
            {
                enemySetup._enemyStats.IncreaseDifficulty();
                Debug.Log("Increasing difficulty");
            }
            else
            {
                enemySetup._enemyStats.ResetStats();
                Debug.Log("Reseting difficulty");
            }
        }



       
    }
}
 