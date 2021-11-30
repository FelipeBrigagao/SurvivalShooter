using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonBase<PlayerManager>
{
    #region Variables

    [SerializeField]
    private GameObject _playerPrefab;

    public bool playerIsDead { get; private set;}

    public int _currentPoints { get; private set; }

    public GameObject _currentPlayer { get; private set; }

    #endregion

    #region Events

    public event Action OnPlayerDeath;

    public void PlayerDied()
    {
        OnPlayerDeath?.Invoke();

        playerIsDead = true;
    }


    #endregion

    #region UnityMethods
    #endregion

    #region Methods

    public void SetCurrentPlayer(GameObject player)
    {
        _currentPlayer = player;
    }

    public void InstantiatePlayer()
    {
        _currentPlayer = SpawnManager.Instance.SpawnPlayer(_playerPrefab);
    }

    public void AddPoints(int pointsGained)
    {
        _currentPoints += pointsGained;
        UIManager.Instance.UpdateScoreUI();
    }

    public void InitiatePoints()
    {
        _currentPoints = 0;
    }

    #endregion
}
