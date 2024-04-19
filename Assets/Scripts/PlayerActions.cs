using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    public GameObject bulletTemplate;
    public float health = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            GameObject bullet = Instantiate(bulletTemplate, 
                transform.position + new Vector3(0.0f,0.6f, 0.0f), 
                transform.rotation);
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
        
    }

	private void OnCollisionStay(Collision collisionInfo)
	{
        if (collisionInfo.gameObject.CompareTag("EnemyShip"))
        {
            health = health - 10.0f;
            Debug.Log("Current Health: " + health);
            Destroy(collisionInfo.gameObject);
        }
	}
}
