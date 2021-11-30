using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    private void Awake()
    {
        InitiateRound();
    }

    private void InitiateRound()
    {
        GameManager.Instance.StartRound();
    }
}
