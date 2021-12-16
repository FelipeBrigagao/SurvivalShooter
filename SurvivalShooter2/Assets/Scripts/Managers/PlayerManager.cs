using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : SingletonBase<PlayerManager>
{
    #region Variables

    [SerializeField]
    private GameObject _playerPrefab;

    private CinemachineVirtualCamera _playerCam;

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
        playerIsDead = false;
        _currentPlayer = SpawnManager.Instance.SpawnPlayer(_playerPrefab);

        _playerCam.Follow = _currentPlayer.transform;
        _playerCam.LookAt = _currentPlayer.transform;

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

    public void SetPlayerCam(CinemachineVirtualCamera playerCam)
    {
        _playerCam = playerCam;
    }
    #endregion
}
