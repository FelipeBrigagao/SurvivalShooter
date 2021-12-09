using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickable : PickableBase
{
    #region Variables
    [SerializeField] private int _healAmount;
        
    #endregion

    #region Unity Methods
    #endregion

    #region Methods
    public override void PickUp(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        playerHealth?.Heal(_healAmount);
        _animator.SetTrigger(_pickedTrigger);
        _pickableSound.Play();

    }

    public void DestroyPickUp()
    {
        Destroy(this.gameObject);
    }
    #endregion
}
