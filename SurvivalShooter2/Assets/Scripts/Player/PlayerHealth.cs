using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealth : HealthBase
{
    #region Variables
    [Header("Player references")]
    private PlayerAnimation _playerAnim;
    private AudioSource playerAudio;
    public AudioClip deathAudio;

    [Header("Player hurt screen animation")]
    [SerializeField] private Image _hurtFlashScreen;
    [SerializeField] private float _flashSpeed = 1f;
    [SerializeField] private Color _flashColor = new Color(1f, 0f, 0f, 0.1f);
    private Color _flashInitialColor = new Color(0f, 0f, 0f, 0f);

    #endregion

    #region Unity Methods
    protected override void Start()
    {
        base.Start();

        _playerAnim = GetComponent<PlayerAnimation>();
        playerAudio = GetComponent<AudioSource>();
    }
    #endregion


    #region Methods
    public override void TakeDamage(int damageTaken)
    {
        base.TakeDamage(damageTaken);
    }

    protected override void HurtReaction()
    {
        base.HurtReaction();
        UIManager.Instance.UpdateHealthUI(_currentHealth);
        FlashScreen();
        playerAudio.Play();
    }

    protected override void Die()
    {
        base.Die();

        _playerAnim.PlayerDie();
        playerAudio.clip = deathAudio;
        playerAudio.Play();
        PlayerManager.Instance.PlayerDied();
    }

    private void FlashScreen()
    {
        _hurtFlashScreen.DOKill(true);
        _hurtFlashScreen.color = _flashColor;
        _hurtFlashScreen.DOColor(_flashInitialColor, _flashSpeed).SetEase(Ease.OutQuint);
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    #endregion
}
