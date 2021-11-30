using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    #region Variables
    public Animator transitionAnim;

    float waitForAnimationTime = 7f;
    #endregion

    #region Unity Methods
    #endregion

    #region Methods
    public void EnterGame()
    {
        StartCoroutine(TransitionToGame());
    }

    IEnumerator TransitionToGame()
    {
        transitionAnim.SetTrigger("Start");

        yield return new WaitForSeconds(waitForAnimationTime);

        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Button pressed");
        Application.Quit();
    }
    #endregion





}
