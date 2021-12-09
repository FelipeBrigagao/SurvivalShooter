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
    private WaveUI _waveUI;
    private Fade _fade;

    #endregion

    #region UnityMethods
    
    private void Start()
    {
        PlayerManager.Instance.OnPlayerDeath += PlayerDied;

    }

    private void OnDestroy()
    {
        PlayerManager.Instance.OnPlayerDeath -= PlayerDied;
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

    private void DisableScoreTXT()
    {
        _scoreTXT.enabled = false;
    }

    private void EnableScoreTXT()
    {
        _scoreTXT.enabled = true;
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
    private void EnablePlayerHealthIMG()
    {
        _playerHealthUI.SetActive(true);
    }
    private void DisablePlayerHealthIMG()
    {
        _playerHealthUI.SetActive(false);
    }

    public void ChangeWaveUITXT(string waveUITXT)
    {
        _waveUI.ChangeWave(waveUITXT);
    }

    private void EnableGameOverScreen()
    {
        _gameOverScreen.SetActive(true);
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

    public void StartGameFade()
    {
        _fade.EnterGameFade();
    }

    public void ChangeScenesFade()
    {
        _fade.ChangeScenesFade();
    }

    public void SetScoreTXT(Text scoreTXT)
    {
        _scoreTXT = scoreTXT;
    }

    public void SetHealthUI(GameObject healthUI)
    {
        _playerHealthUI = healthUI;
    }

    public void SetGameOverScreenUI(GameObject gameOverScreen)
    {
        _gameOverScreen = gameOverScreen;
    }

    public void SetWaveUI(WaveUI waveUI)
    {
        _waveUI = waveUI;
    }

    public void SetFade(Fade fade)
    {
        _fade = fade;
    }
    #endregion
}
