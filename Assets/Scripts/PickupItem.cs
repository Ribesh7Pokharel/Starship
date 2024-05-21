using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
        {
            PlayerActions player = other.gameObject.GetComponent<PlayerActions>();
            player.gameMode.itemCollected += 1;

            player.gameMode.itemPickupOn();

            Destroy(gameObject.transform.parent.gameObject);
        }
	}
}
