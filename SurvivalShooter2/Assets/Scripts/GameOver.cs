using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    PlayerStats ps;
    Text scoreTXT;
    
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        scoreTXT = GameObject.FindGameObjectWithTag("ScoreGameOverTXT").GetComponent<Text>();
        StartCoroutine(ShowPoints());
    }


    void Update()
    {

             
    }



    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0); //scene 0 é o menu
    }


    IEnumerator ShowPoints()
    {
        int i = 0;

        yield return new WaitForSeconds(1f);


        while(i < ps.GetActualPoints())
        {
            i++;
            scoreTXT.text = "Score: " + i;
            yield return null;
        }
    }
}
