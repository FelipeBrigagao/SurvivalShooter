using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBase<UIManager>
{
    #region Variables

    [Header("UI references")]
    [SerializeField] private Text _scoreTXT;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _playerHealthUI;

    private HealthSlider _playerHealthSlider;

    #endregion

    #region UnityMethods
    
    private void Start()
    {
        PlayerManager.Instance.OnPlayerDeath += PlayerDied;

    }


    #endregion

    #region Methods

    public void UpdateScoreUI()
    {
        _scoreTXT.text = $"Score: {PlayerManager.Instance._currentPoints}";
    }

    public void InitiateScoreUI()
    {
        UpdateScoreUI();
    }

    public void SetMaxtHealthUI()
    {
        _playerHealthSlider.SetMaxHealth(PlayerManager.Instance._currentPlayer.GetComponent<PlayerHealth>().GetMaxHealth());
    }
    
    public void InitiateHealthUI()
    {
        _playerHealthSlider = _playerHealthUI.GetComponent<HealthSlider>();
        SetMaxtHealthUI();
        _playerHealthSlider.InitiateHealthUI();
    }

    public void UpdateHealthUI(int health)
    {
        _playerHealthSlider.UpdateCurrentHealthUI(health);
    }

    private void EnableGameOverScreen()
    {
        _gameOverScreen.SetActive(true);
    }

    private void DisablePlayerHealthIMG()
    {
        _playerHealthUI.SetActive(false);
    }

    private void DisableScoreTXT()
    {
        _scoreTXT.enabled = false;
    }

    private void EnablePlayerHealthIMG()
    {
        _playerHealthUI.SetActive(true);
    }

    private void EnableScoreTXT()
    {
        _scoreTXT.enabled = true;
    }


    public void GamePaused()
    {
        DisableScoreTXT();
        DisablePlayerHealthIMG();
    }

    public void GameResumed()
    {
        EnableScoreTXT();
        EnablePlayerHealthIMG();
    }


    private void PlayerDied()
    {
        EnableGameOverScreen();
        DisablePlayerHealthIMG();
        DisableScoreTXT();
    }

    public void InitiateGameUI()
    {
        EnablePlayerHealthIMG();
        EnableScoreTXT();
        InitiateScoreUI();
        InitiateHealthUI();
    }



    public void GO_SetScoreTXT(Text scoreTXT)
    {
        _scoreTXT = scoreTXT;
    }

    public void GO_SetHealthUI(GameObject healthUI)
    {
        _playerHealthUI = healthUI;
    }

    public void GO_SetGameOverScreen(GameObject gameOverScreen)
    {
        _gameOverScreen = gameOverScreen;
    }

    private void OnDestroy()
    {
        PlayerManager.Instance.OnPlayerDeath -= PlayerDied;
    }

    #endregion
}
