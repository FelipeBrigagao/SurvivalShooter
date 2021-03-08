using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    Slider slider;
    PlayerStats ps;

    Image[] heartUI;


    void Start()
    {
        PlayerStats.OnPlayerDeath += PlayerDied;

        slider = GetComponent<Slider>();
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    
        if(ps != null)
        {
            SetMaxHealth(ps.GetMaxHealth());
        }


        heartUI = GetComponentsInChildren<Image>();


    }

    private void Update()
    {
        SetActualHealth(ps.GetActualHealth());

        if (PauseMenu.gameIsPaused && heartUI[0].enabled)
        {
            foreach(Image imagem in heartUI)
            {
                imagem.enabled = false;
            }

        }else if (!PauseMenu.gameIsPaused && !heartUI[0].enabled)
        {
            foreach (Image imagem in heartUI)
            {
                imagem.enabled = true;
            }

        }


    }


    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void SetActualHealth(int actualHealth)
    {
        slider.value = actualHealth;
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
