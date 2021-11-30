using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    #region Variables
    public GameObject pausedMenu;
    #endregion

    #region Unity Methods
    void Update()
    {
        if (!PlayerManager.Instance.playerIsDead)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameManager.Instance.gameIsPaused)
                {
                    ResumeGame();

                }
                else if (!GameManager.Instance.gameIsPaused)
                {
                    Paused();

                }
            }

        }

    }
    #endregion


    #region Methods
    public void ResumeGame()
    {
        pausedMenu.SetActive(false);
        Time.timeScale = 1f;
        GameManager.Instance.ResumeGame();
        UIManager.Instance.GameResumed();
    }

    void Paused()
    {
        pausedMenu.SetActive(true);
        Time.timeScale = 0f;
        GameManager.Instance.PauseGame();
        UIManager.Instance.GamePaused();
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        ScenesManager.Instance.LoadMenuScene();
    }
    #endregion







}
