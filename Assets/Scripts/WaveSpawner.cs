using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //public EnemySpawner spwanEnemy;
	public enum SpwanState { Spawning, Waiting, Counting};
	[System.Serializable]
	public class Wave
	{
		public string name;
		public Transform enemy;
		public int count;
		public float rate;
	}

	public Wave[] waves;
	private int nextWave = 0;


	public float timeBetweenWaves = 5f;
	public float waveCountdown;

    private float searchCountDown = 1f;

	private SpwanState state = SpwanState.Counting;
	// Start is called before the first frame update
	void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpwanState.Waiting)
        {
            if (!EnemyIsAlive()) 
            {
               WaveCompleted();
            } 
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpwanState.Spawning) 
            {
                StartCoroutine(SpwanWave(waves[nextWave]));
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
    }
     void WaveCompleted()
    {
        state = SpwanState.Counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 >  waves.Length - 1)
        {
            nextWave = 0;
        }
        else
        {
            nextWave++;
        }
    }
    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("EnemyShip") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpwanWave (Wave _wave)
    {
        state = SpwanState.Spawning;
        for (int i = 0; i < _wave.count; i++)
        {
            spawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpwanState.Waiting;
        yield break;
    }

    void spawnEnemy(Transform enemy)
    {
        Instantiate (enemy, transform.position, transform.rotation);
    }

}
