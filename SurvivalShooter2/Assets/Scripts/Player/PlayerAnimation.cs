using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    #region Variables
    [Header("Animation parameters")]
    [SerializeField] private string _playerDeathTrigger;
    [SerializeField] private string _playerWalkParameter;

    private Animator _playerAnim;
    
    #endregion

    #region UnityMethods
    private void Start()
    {
        _playerAnim = GetComponent<Animator>();
    }

    #endregion

    #region Methods

    public void PlayerDie()
    {
        _playerAnim.SetTrigger(_playerDeathTrigger);
    }

    public void PlayerMove(float movement)
    {
        _playerAnim.SetFloat(_playerWalkParameter, movement);
    }


    #endregion
}
