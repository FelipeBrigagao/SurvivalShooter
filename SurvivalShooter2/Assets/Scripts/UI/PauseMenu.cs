using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject pausedMenu;
    [SerializeField] private Transform pauseElements;
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
        for(int i = 0; i < pauseElements.childCount; i++)
        {
            pauseElements.GetChild(i).gameObject.SetActive(false);
        }

        GameManager.Instance.ResumeGame();
    }

    void Paused()
    {
        pausedMenu.SetActive(true);
        GameManager.Instance.PauseGame();
    }

    public void ReturnToMenu()
    {
        GameManager.Instance.ResumeGame();
        StartCoroutine(GameManager.Instance.ReturnToMainMenu());
    }
    #endregion







}
