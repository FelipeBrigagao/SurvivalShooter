using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    #region Variables
    public Animator transitionAnim;
    #endregion

    #region Unity Methods
    #endregion

    #region Methods
    public void EnterGame()
    {
        StartCoroutine(GameManager.Instance.StartGame());
    }


    public void ExitGame()
    {
        Debug.Log("Exit Button pressed");
        Application.Quit();
    }
    #endregion





}
