using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    #region Variables
    private Animator _enemyAnim;
    [SerializeField] private string _walkParameterName;
    [SerializeField] private string _deathTriggerName;
    
    #endregion

    #region Unity Methods
    private void Start()
    {
        _enemyAnim = GetComponent<Animator>();
    }
    #endregion

    #region Methods

    public void EnemyMoveAnimation(float enemySpeed)
    {
        _enemyAnim.SetFloat(_walkParameterName, enemySpeed);
    }

    public void EnemyDeathAnimation()
    {
        _enemyAnim.SetTrigger(_deathTriggerName);
    }


    #endregion
}
