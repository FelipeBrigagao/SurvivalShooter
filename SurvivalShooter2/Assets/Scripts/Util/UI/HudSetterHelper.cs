using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudSetterHelper : MonoBehaviour
{
    #region Variables
    [SerializeField] Text _scoreTXT;
    [SerializeField] GameObject _healthUI;
    [SerializeField] GameObject _gameOverScreen;
    [SerializeField] WaveUI _waveUI;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        SetScoreTXT();
        SetHealthUI();
        SetGameOverScreen();
        SetWaveUI();
    }
    #endregion

    #region Methods
    private void SetScoreTXT()
    {
        UIManager.Instance.SetScoreTXT(_scoreTXT);
    }
    private void SetHealthUI()
    {
        UIManager.Instance.SetHealthUI(_healthUI);
    }
    private void SetGameOverScreen()
    {
        UIManager.Instance.SetGameOverScreenUI(_gameOverScreen);
    }

    private void SetWaveUI()
    {
        UIManager.Instance.SetWaveUI(_waveUI);
    }
    #endregion
}
