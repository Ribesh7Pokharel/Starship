using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerActions : MonoBehaviour
{

    public GameObject bulletTemplate;
    public float health = 50.0f;
    public ShipGameMode gameMode;
    public GameObject laserprefab;
    public float minX = -9.48f, maxX = 9.46f, minY = -1.83f, maxY = 2.91f;
    public Vector3 laserOffset = new Vector3(0,1,0);
    public float canFire = 0f;
    public float fireRate = 9.0f;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (!gameMode.gameOver)
            {
                GameObject bullet = Instantiate(bulletTemplate,
                    transform.position + new Vector3(0.0f, 0.6f, 0.0f),
                    transform.rotation);
                GetComponent<AudioSource>().Play();
            }
        }
        if (Input.GetKey (KeyCode.A)) 
        {
            transform.position += new Vector3(-0.02f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D)) 
        {
			transform.position += new Vector3(+0.02f, 0.0f, 0.0f);
		}
        if (Input.GetKey(KeyCode.W)) 
        {
			transform.position += new Vector3(0.0f, +0.02f, 0.0f);
		}
        if ((Input.GetKey(KeyCode.S)))
        {
            transform.position += new Vector3(0.0f, -0.02f, 0.0f);
        }
        if (Input.GetKey(KeyCode.R) && gameMode.gameOver == true)
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKey(KeyCode.Q) && Time.time > canFire)
		{
			FireLaser();
		}

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), 0);
        
    }

	public void FireLaser()
	{
		if (!gameMode.gameOver)
		{
			canFire = Time.time + fireRate;
			GameObject laser = Instantiate(laserprefab,
				transform.position + new Vector3(0.0f, 0.6f, 0.0f),
				transform.rotation);
			GetComponent<AudioSource>().Play();
		}
	}

	private void OnCollisionStay(Collision collisionInfo)
	{
        if (collisionInfo.gameObject.CompareTag("EnemyShip"))
        {
            health = health - 10.0f;
            Debug.Log("Current Health: " + health);
            EnemyShip enemy = collisionInfo.gameObject.GetComponent<EnemyShip>();
            StartCoroutine(enemy.destroyActor(null));
        }
        else if(collisionInfo.gameObject.CompareTag("BigEnemy"))
        {
                health = health - 20.0f;
                Destroy(collisionInfo.gameObject);
        }

         if (health <= 0.0f) 
         {
            gameMode.gameOver = true;
            GetComponent<Collider>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
         }
    
	}
}
