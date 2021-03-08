using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject pausedMenu;
    

    bool playerDead = false;


    private void Start()
    {
        PlayerStats.OnPlayerDeath += PlayerDied;
    }

    void Update()
    {
        if (!playerDead)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused)
                {
                    ResumeGame();

                }else if (!gameIsPaused)
                {
                    Paused();

                }
            }

        }

    }

    public void ResumeGame()
    {
        pausedMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Paused()
    {
        pausedMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }


    void PlayerDied()
    {
        playerDead = true;
    }

    private void OnDestroy()
    {
        PlayerStats.OnPlayerDeath -= PlayerDied;
    }



}
