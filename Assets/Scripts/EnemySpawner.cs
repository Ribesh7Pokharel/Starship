using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject enemyPrefab;

	[SerializeField]
	private float enemyInterval = 3.5f;

	[SerializeField]
	private GameObject bigEnemyPrefab;

	[SerializeField]
	private float bigEnemyInterval = 9.0f;
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(spwanEnemy(enemyInterval, enemyPrefab));
		StartCoroutine(spwanEnemy(bigEnemyInterval, bigEnemyPrefab));
	}

	// Update is called once per frame
	void Update()
	{

	}

	private IEnumerator spwanEnemy(float interval, GameObject enemy)
	{
		yield return new WaitForSeconds(interval);
		GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-7f, 7), Random.Range(7f, 7f), 0), Quaternion.identity);
		StartCoroutine(spwanEnemy(interval, enemy));
	}

	private IEnumerator spwanBigEnemy(float interval, GameObject enemy)
	{
		yield return new WaitForSeconds(interval);
		GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-7f, 7), Random.Range(7f, 7f), 0), Quaternion.identity);
		StartCoroutine(spwanEnemy(interval, enemy));
	}
}