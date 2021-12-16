using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WaveUI : MonoBehaviour
{
    #region Variable
    [SerializeField] private Text _waveTXT;
    [SerializeField] private float _effectDuration;
    [SerializeField] private float _effectDelay;
    #endregion

    #region Unity Methods
    #endregion

    #region Methods
    public void ChangeWave(string waveTXT)
    {
        _waveTXT.text = waveTXT;

        _waveTXT.DOFade(1, _effectDuration).From(0).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo).SetDelay(_effectDelay);
    }

    #endregion

}
