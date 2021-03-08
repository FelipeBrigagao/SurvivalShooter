using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    int maxHealth = 100;
    int currentHealth;

    public int actualPoints = 0;

    Animator animPlayer;
    AudioSource playerAudio;
    public AudioClip deathAudio;
    public GameObject gameOverScreen;

    Image hurtFlashThing;
    float flashSpeed = 5f;

    bool isDead = false;
    bool hurt = false;

    void Start()
    {
        animPlayer = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        hurtFlashThing = GameObject.FindGameObjectWithTag("HurtFlash").GetComponent<Image>();

        OnPlayerDeath += Die;

    }


    private void Update()
    {
        if (hurt)
        {
            hurtFlashThing.color = new Color(1f, 0f, 0f, 0.1f);
            hurt = false;
        
        }else if (!hurt)
        {
            hurtFlashThing.color = Color.Lerp(hurtFlashThing.color, Color.clear, flashSpeed * Time.deltaTime);

        }
    }


    public void TakeDamage(int damageTaken)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= damageTaken;
        hurt = true;
        playerAudio.Play();
            
        if(currentHealth <= 0)
        {
            currentHealth = 0;

            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();

            }
        }
        
    }

    public void AddPoints(int pointsGained)
    {
        actualPoints += pointsGained;
    }


    void Die()
    {
        isDead = true;
        playerAudio.clip = deathAudio;
        playerAudio.Play();
        
        animPlayer.SetTrigger("Die");
    }

   


    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetActualHealth()
    {
        return currentHealth;
    }

    public int GetActualPoints()
    {
        return actualPoints;
    }

    public void RestartLevel()
    {
        //Tela game over
        gameOverScreen.SetActive(true);
    }


    private void OnDestroy()
    {
        OnPlayerDeath -= Die;
    }

}
