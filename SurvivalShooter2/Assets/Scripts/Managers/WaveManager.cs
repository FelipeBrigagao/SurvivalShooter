using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : SingletonBase<WaveManager>
{
    #region Variables
    [SerializeField] private Wave[] _waves;
    [SerializeField] private float _timeBetweenWaves;
    [SerializeField] private int _startingWave;
    [SerializeField] private int _currentWave;
    [SerializeField] private int _waveIndex;

    [SerializeField] private Transform _spawnsHolder;
    private Vector3[] _spawnsPosition;
    private float _countdownSpawnWave;

    [SerializeField] private List<GameObject> _enemiesSpawned;

    [SerializeField] private WavesStates _currentState;

    #endregion

    #region Unity Methods
    protected override void Awake()
    {
        base.Awake();
        _enemiesSpawned = new List<GameObject>();

        _spawnsPosition = new Vector3[_spawnsHolder.childCount];

        for(int i = 0; i<_spawnsPosition.Length; i++)
        {
            _spawnsPosition[i] = _spawnsHolder.GetChild(i).transform.position;
        }
    
    }

    private void Update()
    {

        switch (_currentState)
        {
            case WavesStates.STARTING_WAVE:
                break;

            case WavesStates.SPAWNING:
                
                if(_countdownSpawnWave <= 0)
                {
                    _currentState = WavesStates.WAITING;
                    Debug.Log("Entered waiting state.");
                }
                else
                {
                    _countdownSpawnWave -= Time.deltaTime;

                }
                break;
            
            case WavesStates.WAITING:
                
                if(_enemiesSpawned.Count == 0)
                {
                    _currentState = WavesStates.STARTING_WAVE;
                    Debug.Log("Entered starting wave state.");
                    _currentWave++;
                    StartCoroutine(StartWave());
                }

                break;
            default:
                break;
        }

        
    }


    #endregion

    #region Methods

    public void InitiateWaves()
    {
        _currentWave = _startingWave;

        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        UIManager.Instance.ChangeWaveUITXT($"Wave {_currentWave}");

        if(_currentWave >= _waves.Length)
        {
            _waveIndex = _waves.Length - 1;
        }
        else
        {
            _waveIndex = _currentWave;
        }

        _countdownSpawnWave = _waves[_waveIndex].waveDuration;

        yield return new WaitForSeconds(_timeBetweenWaves);

        _currentState = WavesStates.SPAWNING;

        Debug.Log("Entered spawning state.");

        foreach(var enemy in _waves[_waveIndex].enemiesToSpawn)
        {
            StartCoroutine(SpawnEnemy(enemy));
        }

    }


    IEnumerator SpawnEnemy(GameObject enemyToSpawn)
    {
        EnemySetup enemySetup = enemyToSpawn.GetComponent<EnemySetup>();

        GameObject enemySpawned;

        yield return new WaitForSeconds(enemySetup._enemyStats.firstTimeToSpawn);

        while(_currentState == WavesStates.SPAWNING)
        {
            enemySpawned = SpawnManager.Instance.SpawnEnemy(enemyToSpawn, GetARandomSpawnPosition());

            _enemiesSpawned.Add(enemySpawned);

            yield return new WaitForSeconds(enemySetup._enemyStats.timeToSpawn);
        }

    }


    private Vector3 GetARandomSpawnPosition()
    {
        int index = Random.Range(0, _spawnsPosition.Length);

        return _spawnsPosition[index];
    }


    public void RemoveSpawnedEnemy(GameObject deadEnemy)
    {
        _enemiesSpawned.Remove(deadEnemy);
    }

    public void SetSpawnsHolder(Transform spawnsHolder)
    {
        _spawnsHolder = spawnsHolder;
    }
    #endregion
}

public enum WavesStates
{
    NONE,
    STARTING_WAVE,
    SPAWNING,
    WAITING
}