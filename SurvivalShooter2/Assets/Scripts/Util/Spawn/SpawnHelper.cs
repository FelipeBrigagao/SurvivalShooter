using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHelper : MonoBehaviour
{
    #region Variables
    [Header("Spawn references")]
    [SerializeField] private Transform _playerSpawn;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SetPlayerSpawnPoint();
    }
    #endregion

    #region Methods
    private void SetPlayerSpawnPoint()
    {
        SpawnManager.Instance.SetPlayerSpawnPosition(_playerSpawn);
    }
    #endregion
}
