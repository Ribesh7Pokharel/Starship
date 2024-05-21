using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
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
            StartCoroutine(destroyActor(collisionInfo.gameObject));
        }
    }

    public IEnumerator destroyActor (GameObject bullet)
    {
        if (bullet != null)
        {
            Destroy(bullet);
        }
        GetComponent<Collider>().enabled = false;
        GetComponent<Animator>().runtimeAnimatorController = explosion;
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
}
