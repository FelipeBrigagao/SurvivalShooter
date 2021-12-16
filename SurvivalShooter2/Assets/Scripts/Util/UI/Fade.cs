using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [Header("Animator reference")]
    [SerializeField]private Animator _fadeAnim;

    [Header("Animations Triggers")]
    [SerializeField] private string _enterGameTrigger;
    [SerializeField] private string _normalFadeTrigger;

    private void Awake()
    {
        UIManager.Instance.SetFade(this);
    }

    public void EnterGameFade()
    {
        _fadeAnim.SetTrigger(_enterGameTrigger);
    }

    public void ChangeScenesFade()
    {
        _fadeAnim.SetTrigger(_normalFadeTrigger);
    }

}
