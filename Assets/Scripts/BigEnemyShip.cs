using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyShip : MonoBehaviour
{
	public float health = 20.0f;
	public RuntimeAnimatorController explosion;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
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
			health = health - 10.0f;
			Destroy(collisionInfo.gameObject);
			if (health == 0)
			{
				Destroy(this.gameObject);
				Destroy(collisionInfo.gameObject);
			}
		}

		if (collisionInfo.gameObject.CompareTag("Laser"))
		{
			Destroy(this.gameObject);
			Destroy(collisionInfo.gameObject);
			StartCoroutine(blow());
		}
	}

	public IEnumerator blow()
	{
		//GetComponent<Collider>().enabled = false;
		GetComponent<Animator>().runtimeAnimatorController = explosion;
		yield return new WaitForSeconds(2.0f);
		//Destroy(this.gameObject);
	}
}