using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossShip : MonoBehaviour
{
	public float health = 100.0f;
	public Slider bossHealth;

	void Start()
	{
	}

	void Update()
	{
		bossHealth.value = health;
	}

	void OnCollisionStay(Collision collisionInfo)
	{
		if (collisionInfo.gameObject.CompareTag("Bullet"))
		{
			health -= 10.0f;
			Destroy(collisionInfo.gameObject);
			CheckHealth();
		}

		if (collisionInfo.gameObject.CompareTag("Laser"))
		{
			health -= 20.0f;
			Destroy(collisionInfo.gameObject);
			CheckHealth();
		}
	}

	private void CheckHealth()
	{
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
