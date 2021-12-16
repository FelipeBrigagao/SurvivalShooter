using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using System;


public class EnemyHealth : HealthBase
{
    #region Variables
    private EnemySetup _enemySetup;
    private AudioSource _enemySound;
    private EnemyAnimation _enemyAnim;
    
    [SerializeField] private float _sinkingSpeed = 5f;
    [SerializeField] private float _sinkingDepth = -10f;

    [SerializeField] private DropEffectPickUp _drop;
    #endregion

    #region Events
    public event Action OnEnemyDeath;

    public void EnemyDied()
    {
        OnEnemyDeath?.Invoke();
    }
    #endregion


    #region Unity Methods
    protected override void Start()
    {
        _enemySetup = GetComponent<EnemySetup>();
        _maxHealth = _enemySetup._enemyStats.enemyMaxHealth;

        base.Start();

        _enemySound = GetComponent<AudioSource>();
        _enemyAnim = GetComponent<EnemyAnimation>();
        _drop = GetComponent<DropEffectPickUp>();
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
        _enemySound.Play();

    }

    protected override void Die()
    {
        base.Die();

        EnemyDied();
        _enemySound.clip = _enemySetup._enemyStats.enemyDeathSound;
        _enemySound.Play();

        PlayerManager.Instance.AddPoints(_enemySetup._enemyStats.enemyPoints);
        WaveManager.Instance.RemoveSpawnedEnemy(this.gameObject);
        _drop.DropPickUp(_enemySetup._enemyStats.dropPickupPossibility);

        _enemyAnim.EnemyDeathAnimation();

    }


    public void StartSinking()
    {
        transform.DOMoveY(_sinkingDepth,_sinkingSpeed);

        this.GetComponent<NavMeshAgent>().enabled = false;

        Destroy(gameObject, 2f);

    }
    #endregion

}
