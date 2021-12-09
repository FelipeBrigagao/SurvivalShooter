using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : SingletonBase<WaveManager>
{
    #region Variables
    [Header("Waves controller values")]
    [SerializeField] private Wave[] _waves;
    [SerializeField] private float _timeBetweenWaves;
    [SerializeField] private int _startingWave;
    [SerializeField] private int _currentWave;
    [SerializeField] private int _waveIndex;
    
    [SerializeField] private WavesStates _currentState;

    [Header("Enemy spawn reference")]
    [SerializeField] private Transform _spawnsHolder;
    private Vector3[] _spawnsPosition;
    private float _countdownSpawnWave;

    [SerializeField] private List<GameObject> _enemiesSpawned;

    [Header("Ambient reference")]
    [SerializeField] private Light _ambientLight;

    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        PlayerManager.Instance.OnPlayerDeath += StopSpawning;
    }

    private void OnDestroy()
    {
        PlayerManager.Instance.OnPlayerDeath -= StopSpawning;
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
        _enemiesSpawned = new List<GameObject>();

        _spawnsPosition = new Vector3[_spawnsHolder.childCount];

        for (int i = 0; i < _spawnsPosition.Length; i++)
        {
            _spawnsPosition[i] = _spawnsHolder.GetChild(i).transform.position;
        }

        _currentWave = _startingWave;

        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        UIManager.Instance.ChangeWaveUITXT($"Wave {_currentWave + 1}");

        if(_currentWave >= _waves.Length)
        {
            _waveIndex = _waves.Length - 1;
            _waves[_waveIndex].ApplyWaveEffects(true);
        }
        else
        {
            _waveIndex = _currentWave;
            _waves[_waveIndex].ApplyWaveEffects(false);
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

    public void StopSpawning()
    {
        StopAllCoroutines();
        _currentState = WavesStates.NONE;
    }


    public void SetAmbientLight(Light ambientLight)
    {
        _ambientLight = ambientLight;
    }

    public void ChangeAmbientLight(Color ambientColor)
    {
        _ambientLight.color = ambientColor;
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