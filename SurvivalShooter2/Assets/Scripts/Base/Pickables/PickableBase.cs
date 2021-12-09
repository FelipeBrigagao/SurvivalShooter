using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickableBase : MonoBehaviour
{
    #region Variables
    [SerializeField] private string _interactableCharacterTag;
    [SerializeField] protected AudioSource _pickableSound;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected string _pickedTrigger;
    private bool _alreadyPicked;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _pickableSound = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _alreadyPicked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_interactableCharacterTag) && !_alreadyPicked)
        {
            PickUp(other);
        }
    }
    #endregion

    #region Methods
    public abstract void PickUp(Collider other);
    #endregion

}
