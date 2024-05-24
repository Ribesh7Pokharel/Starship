using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShip : MonoBehaviour
{
	public delegate void BossDestroyedHandler();
	public event BossDestroyedHandler onBossDestroyed;

	public float health = 100.0f;

	void Update()
	{
		transform.position += new Vector3(0.0f, -0.005f, 0.0f);
		if (transform.position.y < -5.0f)
		{
			Destroy(this.gameObject);
		}
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
			if (onBossDestroyed != null)
			{
				onBossDestroyed.Invoke();
			}
			Destroy(gameObject);
		}
	}
}
