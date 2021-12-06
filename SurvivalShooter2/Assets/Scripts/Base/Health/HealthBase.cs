using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    #region Variables
    [Header("Health values")]
    [SerializeField] protected int _maxHealth;
    protected int _currentHealth;

    [SerializeField] private bool _destroyOnDeath;
    protected bool _isDead;
    #endregion

    #region Unity Methods
    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
    }
    #endregion

    #region Methods

    public virtual void TakeDamage(int damageTaken)
    {
        if (_isDead)
        {
            return;
        }

        _currentHealth -= damageTaken;

        HurtReaction();

        if(_currentHealth <= 0)
        {
            _currentHealth = 0;

            Die();
        }

    }

    protected virtual void HurtReaction()
    {

    }

    protected virtual void Die()
    {
        _isDead = true;
        if (_destroyOnDeath)
        {
            Destroy(this.gameObject);
        }
    }

    #endregion
}
