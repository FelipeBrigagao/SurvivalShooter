using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    #region Variables
    public bool gameIsPaused { get; private set;}

    [SerializeField] float _startGameFadeWait;
    [SerializeField] float _scenesChangeFadeWait;

    #endregion

    #region UnityMethods
    #endregion

    #region Methods

    public void PauseGame()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
        UIManager.Instance.GamePaused();
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        UIManager.Instance.GameResumed();
    }

    public IEnumerator StartGame()
    {
        UIManager.Instance.StartGameFade();
        yield return new WaitForSeconds(7f);
        ScenesManager.Instance.LoadGameScene();
    }

    public IEnumerator RetryGame()
    {
        UIManager.Instance.ChangeScenesFade();
        StopRound();
        yield return new WaitForSeconds(2f);
        ScenesManager.Instance.LoadGameScene();
    }

    public IEnumerator ReturnToMainMenu()
    {
        UIManager.Instance.ChangeScenesFade();
        StopRound();
        yield return new WaitForSeconds(2f);
        ScenesManager.Instance.LoadMenuScene();
    }

    public void StartRound()
    {
        PlayerManager.Instance.InstantiatePlayer();
        PlayerManager.Instance.InitiatePoints();
        UIManager.Instance.InitiateGameUI();
        WaveManager.Instance.InitiateWaves();
    }

    public void StopRound()
    {
        UIManager.Instance.GamePaused();
        WaveManager.Instance.StopSpawning();
    }

    #endregion
}
