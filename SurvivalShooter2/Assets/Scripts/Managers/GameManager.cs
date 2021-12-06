using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    #region Variables
    public bool gameIsPaused { get; private set;}

    #endregion

    #region UnityMethods
    #endregion

    #region Methods

    public void PauseGame()
    {
        gameIsPaused = true;
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
    }

    public void StartRound()
    {
        PlayerManager.Instance.InstantiatePlayer();
        PlayerManager.Instance.InitiatePoints();
        UIManager.Instance.InitiateGameUI();
        WaveManager.Instance.InitiateWaves();
    }

    #endregion
}
