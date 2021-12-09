 using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    #region Variables
    [SerializeField] private EnemyHealth _enemyHealth;
    private EnemySetup _enemySetup;
    private NavMeshAgent _agent;
    private GameObject _player;
    private EnemyAnimation _enemyAnim;

    [SerializeField] private LayerMask _playerLayer;

    private float _nextAttack = 0;
    private bool _playerDied;
    private bool _enemyDied;

    #endregion


    #region Unity Methods
    private void OnEnable()
    {
        PlayerManager.Instance.OnPlayerDeath += PlayerDied;
        _enemyHealth.OnEnemyDeath += EnemyDied;
    }

    private void OnDisable()
    {
        PlayerManager.Instance.OnPlayerDeath -= PlayerDied;
        _enemyHealth.OnEnemyDeath -= EnemyDied;
    }
    private void Start()
    {
        _enemySetup = GetComponent<EnemySetup>();
        _agent = GetComponent<NavMeshAgent>();
        _player = PlayerManager.Instance._currentPlayer;
        _enemyAnim = GetComponent<EnemyAnimation>();

        _agent.speed = _enemySetup._enemyStats.enemySpeed;
        _agent.stoppingDistance = _enemySetup._enemyStats.stopDistance;
    }

    void FixedUpdate()
    {
        if (!_enemyDied)
        {
            if (!_playerDied)
            {
                MoveToTarget();
                CheckAttackPlayer();
            }

            AnimateEnemy();
        }
    }

    #endregion


    #region Methods
    private void MoveToTarget()
    {
        if (_player != null)
        {
            _agent.SetDestination(_player.transform.position);
         
            if (_agent.velocity.magnitude < 0.01)
            {
                transform.LookAt(_player.transform);
            }
        }
 

    }

    private void StopEnemy()
    {
        _agent.isStopped = true;
    }

    private void AnimateEnemy()
    {
        _enemyAnim.EnemyMoveAnimation(_agent.velocity.magnitude);
    }


    private void CheckAttackPlayer()
    {
        if (Physics.CheckSphere(transform.position, _enemySetup._enemyStats.enemyAttackRadius, _playerLayer) && Time.time >= _nextAttack)
        {
            _nextAttack = Time.time + _enemySetup._enemyStats.enemyAttackRate;
            _player.GetComponent<PlayerHealth>().TakeDamage(_enemySetup._enemyStats.enemyDamage);
            
        }
    }


    private void PlayerDied()
    {
        _playerDied = true;
        StopEnemy();
    }

    private void EnemyDied()
    {
        _enemyDied = true;
        StopEnemy();
    }

    #endregion

}
