using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{
    EnemyAI eAI;
    AudioSource enemySound;
    [SerializeField] AudioClip deathSound;
    Animator anim;
    PlayerHealth playerStats;

    int enemyPoints;
    int enemyMaxHealth;
    int currentHealth;


    bool dead = false;
    bool sinking = false;

    float sinkingSpeed = 1.5f;



    void Awake()
    {
        switch (this.transform.tag)
        {
            case "Zombunny":
                enemyMaxHealth = 20;
                enemyPoints = 10;
                break;
            case "Zombear":
                enemyMaxHealth = 40;
                enemyPoints = 20;
                break;
            case "Hellephant":
                enemyMaxHealth = 70;
                enemyPoints = 40;
                break;
            case "NightmareBunny":
                enemyMaxHealth = 30;
                enemyPoints = 20;
                break;
            case "NightmareBear":
                enemyMaxHealth = 50;
                enemyPoints = 30;
                break;
            case "NightmareHell":
                enemyMaxHealth = 100;
                enemyPoints = 60;
                break;
            default:
                break;

        }


        currentHealth = enemyMaxHealth;
        eAI = GetComponent<EnemyAI>();
        enemySound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }


    void Update()
    {
        if (sinking)
        {
            transform.Translate(-Vector3.up * sinkingSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damageTaken)
    {
        if (dead)
        {
            return;
        }

        currentHealth -= damageTaken;
        enemySound.Play();

        if(currentHealth <= 0)
        {
            currentHealth = 0;

            Die();
        }
    }


    void Die()
    {
        dead = true;

        eAI.enabled = false;
        enemySound.clip = deathSound;
        enemySound.Play();

        PlayerManager.Instance.AddPoints(enemyPoints);

        anim.SetTrigger("Die");

    }


    public void StartSinking()
    {
        sinking = true;

        GetComponent<NavMeshAgent>().enabled = false;

        Destroy(gameObject, 2f);

    }

}
