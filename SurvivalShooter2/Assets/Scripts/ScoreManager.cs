using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    PlayerStats ps;
    Text scoreTXT;

    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        scoreTXT = GetComponentInChildren<Text>();

        PlayerStats.OnPlayerDeath += PlayerDied;
    
    }

    void Update()
    {
        scoreTXT.text = ("Score: " + ps.GetActualPoints());

        if (PauseMenu.gameIsPaused && scoreTXT.enabled)
        {
            scoreTXT.enabled = false;
        }
        else if(!PauseMenu.gameIsPaused && !scoreTXT.enabled)
        {
            scoreTXT.enabled = true;
        }


    }

    void PlayerDied()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        PlayerStats.OnPlayerDeath -= PlayerDied;
    }

}
