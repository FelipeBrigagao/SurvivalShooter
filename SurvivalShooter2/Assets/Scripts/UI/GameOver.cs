using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    #region Variables
    [SerializeField] private Text _scoreTXT;
    [SerializeField] private float _showPointsSpeed = 1f;
    #endregion

    #region Unity Methods
    void Start()
    {
        StartCoroutine(ShowPoints());
    }
    #endregion

    #region Methods
    public void RestartGame()
    {
        StartCoroutine(GameManager.Instance.RetryGame());
    }

    public void ExitGame()
    {
        StartCoroutine(GameManager.Instance.ReturnToMainMenu());
    }


    IEnumerator ShowPoints()
    {
        int i = 0;

        yield return new WaitForSeconds(_showPointsSpeed);


        while (i < PlayerManager.Instance._currentPoints)
        {
            i++;
            _scoreTXT.text = "Score: " + i;
            yield return null;
        }
    }
    #endregion





}
