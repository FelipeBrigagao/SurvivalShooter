using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : SingletonBase<ScenesManager>
{
    #region Variables
    [SerializeField]
    private int _gameSceneIndex;

    [SerializeField]
    private int _menuSceneIndex;

    #endregion

    #region UnityMethods
    #endregion

    #region Methods

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(_menuSceneIndex);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(_gameSceneIndex);
    }


    #endregion
}
