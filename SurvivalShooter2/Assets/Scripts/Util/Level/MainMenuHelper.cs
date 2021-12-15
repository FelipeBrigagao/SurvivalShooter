using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHelper : MonoBehaviour
{
    #region Variables
    #endregion

    #region Unity Methods
    private void Awake()
    {
        InitiateMenuScene();
    }
    #endregion

    #region Methods
    private void InitiateMenuScene()
    {
        AudioManager.Instance.EnterMenuMusic();
    }
    #endregion
}
