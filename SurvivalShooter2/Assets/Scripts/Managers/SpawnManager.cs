using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : SingletonBase<SpawnManager>
{
    #region Variables
    [Header("Player Spawn references")]
    [SerializeField]
    private Transform _playerSpawnPosition;
    #endregion

    #region UnityMethods
    #endregion

    #region Methods
    public void SetPlayerSpawnPosition(Transform playerSpawn)
    {
        _playerSpawnPosition = playerSpawn;
    }

    public GameObject SpawnPlayer(GameObject playerPrefab)
    {
        GameObject player = Instantiate(playerPrefab, _playerSpawnPosition.position, Quaternion.identity);
        return player;
    }

    public GameObject SpawnEnemy(GameObject enemyPrefab, Vector3 spawnPosition)
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        return enemy;
    }

    #endregion
}
