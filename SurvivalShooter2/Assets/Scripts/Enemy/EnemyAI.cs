 using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    Animator anim;
    LayerMask playerLayer;

    int enemyDamage;

    float attackRadius = 1f;
    float attackRate = 2f;
    float nextAttack = 0;

    void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
        player = PlayerManager.Instance._currentPlayer;
        anim = GetComponent<Animator>();
        playerLayer = LayerMask.GetMask("Player");
    
        
        switch (this.transform.tag)
        {
            case "Zombunny":
                enemyDamage = 10;
                attackRadius = 1f;
                attackRate = 2f;
                break;
            case "Zombear":
                enemyDamage = 20;
                attackRadius = 1f;
                attackRate = 2.5f;
                break;
            case "Hellephant":
                enemyDamage = 30;
                attackRadius = 2.2f;
                attackRate = 3f;
                break;
            case "NightmareBunny":
                enemyDamage = 20;
                attackRadius = 1f;
                attackRate = 1.5f;
                agent.speed = 5;
                break;
            case "NightmareBear":
                enemyDamage = 30;
                attackRadius = 1f;
                attackRate = 2f;
                agent.speed = 4;
                break;
            case "NightmareHell":
                enemyDamage = 40;
                attackRadius = 2.2f;
                attackRate = 2.5f;
                agent.speed = 3;
                break;
            default:
                break;

        }

    }

    void FixedUpdate()
    {
        MoveToTarget();
        AnimateEnemy();


        if (Physics.CheckSphere(transform.position, attackRadius, playerLayer) && Time.time >= nextAttack && !PlayerManager.Instance.playerIsDead)
        {
            AttackPlayer();
        }

    }

    private void MoveToTarget()
    {
        if (player != null && !PlayerManager.Instance.playerIsDead)
        {
            agent.SetDestination(player.transform.position);

        }else if (PlayerManager.Instance.playerIsDead && (transform.position - agent.destination).magnitude > 0.1)
        {
            agent.SetDestination(transform.position);    //para o inimigo parar onde está quando o player morrer
            
        }

        if(agent.velocity.magnitude < 0.01)
        {
            transform.LookAt(player.transform);
        }

    }

    private void AnimateEnemy()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }


    void AttackPlayer()
    {
        nextAttack = Time.time + attackRate;
        player.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }



}
