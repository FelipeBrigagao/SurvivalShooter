using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHelper : MonoBehaviour
{
    #region Variables
    [Header("Spawn references")]
    [SerializeField] private Transform _playerSpawn;
    [SerializeField] private Transform _enemySpawnHolder;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        SetPlayerSpawnPoint();
        SetEnemySpawnHolder();
    }
    #endregion

    #region Methods
    private void SetPlayerSpawnPoint()
    {
        SpawnManager.Instance.SetPlayerSpawnPosition(_playerSpawn);
    }

    private void SetEnemySpawnHolder()
    {
        WaveManager.Instance.SetSpawnsHolder(_enemySpawnHolder);
    }
    #endregion
}
