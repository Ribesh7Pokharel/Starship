using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject enemyPrefab;

	[SerializeField]
	private float enemyInterval = 3.5f;

	[SerializeField]
	private GameObject bigEnemyPrefab;

	[SerializeField]
	private GameObject bossPrefab;

	[SerializeField]
	private float bigEnemyInterval = 9.0f;

	[SerializeField]
	private float bossInterval = 50.0f;

	public TextMeshProUGUI gameCompletionText;
	public Button returnToMainMenuButton; // Add a reference to the button

	private Coroutine enemyCoroutine;
	private Coroutine bigEnemyCoroutine;
	private Coroutine bossCoroutine;

	void Start()
	{
		enemyCoroutine = StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));
		bigEnemyCoroutine = StartCoroutine(spawnEnemy(bigEnemyInterval, bigEnemyPrefab));
		bossCoroutine = StartCoroutine(spawnBoss(bossInterval));

		returnToMainMenuButton.gameObject.SetActive(false); // Hide the button initially
	}

	private IEnumerator spawnEnemy(float interval, GameObject enemy)
	{
		while (true)
		{
			yield return new WaitForSeconds(interval);
			Instantiate(enemy, new Vector3(Random.Range(-7f, 7), Random.Range(7f, 7f), 0), Quaternion.identity);
		}
	}

	private IEnumerator spawnBoss(float interval)
	{
		yield return new WaitForSeconds(interval);
		GameObject newBoss = Instantiate(bossPrefab, new Vector3(Random.Range(-7f, 7), Random.Range(7f, 7f), 0), Quaternion.identity);
		BossShip bossShip = newBoss.GetComponent<BossShip>();
		if (bossShip != null)
		{
			bossShip.onBossDestroyed += OnBossDestroyed;
			Debug.Log("Boss spawned and event registered.");
		}
	}

	private void OnBossDestroyed()
	{
		Debug.Log("Boss destroyed. Displaying message and stopping game.");
		ShowGameCompletionMessage("Congratulations! You have defeated the boss.");

		// Stop all coroutines
		if (enemyCoroutine != null)
		{
			StopCoroutine(enemyCoroutine);
		}
		if (bigEnemyCoroutine != null)
		{
			StopCoroutine(bigEnemyCoroutine);
		}
		if (bossCoroutine != null)
		{
			StopCoroutine(bossCoroutine);
		}

		// Destroy all remaining enemies
		DestroyAllEnemies();

		// Stop all game activity
		Time.timeScale = 0;

		// Show the return to main menu button
		returnToMainMenuButton.gameObject.SetActive(true);
	}

	private void DestroyAllEnemies()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyShip");
		foreach (GameObject enemy in enemies)
		{
			Destroy(enemy);
		}

		GameObject[] bigEnemies = GameObject.FindGameObjectsWithTag("BigEnemy");
		foreach (GameObject bigEnemy in bigEnemies)
		{
			Destroy(bigEnemy);
		}
	}

	private void ShowGameCompletionMessage(string message)
	{
		gameCompletionText.text = message;
	}

	public void ReturnToMainMenu()
	{
		Time.timeScale = 1; // Reset time scale to normal
		SceneManager.LoadScene("MainMenu");
	}
}
