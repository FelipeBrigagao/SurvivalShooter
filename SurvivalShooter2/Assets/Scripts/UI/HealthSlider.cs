using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    #region Variables
    [SerializeField] Slider slider;
    #endregion

    #region Unity Methods
    void Start()
    {
        slider = GetComponent<Slider>();
    }
    #endregion

    #region Methods
    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void InitiateHealthUI()
    {
        slider.value = slider.maxValue;
    }

    public void UpdateCurrentHealthUI(int actualHealth)
    {
        slider.value = actualHealth;
    }

    #endregion


}
