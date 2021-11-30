using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Variables
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GunControl _gunControl;
    #endregion

    #region UnityMethods
    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _gunControl = GetComponentInChildren<GunControl>();

    }


    private void Update()
    {
        if(!GameManager.Instance.gameIsPaused && !PlayerManager.Instance.playerIsDead)
        {
            GetMovementInput();
            GetShootInput();
        }
    }
    #endregion

    #region Methods
    
    private void GetMovementInput()
    {
        Vector3 input = Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.forward * Input.GetAxisRaw("Vertical");
        _playerController.SetMovementInput(input);
    }

    private void GetShootInput()
    {
        if (Input.GetButton("Fire1"))
        {
            _gunControl.Shoot();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            _gunControl.StopShooting();
        }
    }
    
    #endregion
}
