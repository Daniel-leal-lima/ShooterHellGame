using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUNTING};
    [System.Serializable]
    public class Wave 
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
        public GameObject Inimigo1;

    }

    public Wave[] waves;
    private int nextWave = 0;
    public float timeBetweenWaves = 5f;
    public float waveCountdowm;
    public Transform siMesmo;
    public bool ativar;

    public SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdowm = timeBetweenWaves;
    }

    void Update()
    {

        if(ativar == true)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
                ativar = false;
            }
        }

        waveCountdowm -= Time.deltaTime;
        
        if (waveCountdowm < 50 && waveCountdowm > 49)
        {
            nextWave = 0;
            ativar = true;
        }
        if (waveCountdowm < 40 && waveCountdowm > 39)
        {
            nextWave = 1;
            ativar = true;
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy (_wave.enemy);
            yield return new WaitForSeconds( 1f/_wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        Instantiate(_enemy, siMesmo.position, Quaternion.Euler(0, 180, 0));
        Debug.Log("Spawnando inimigo: " + _enemy.name);
    }
}
