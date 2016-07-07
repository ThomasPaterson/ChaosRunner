using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour 
{


	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == Tags.player) 
		{
			PowerupManager.instance.RecievePowerup();
			collider2D.enabled = false;
			GetComponent<Animator>().SetTrigger("Die");
			GetComponent<DestroyAfterDelay>().enabled = true;
		}
		
	}
}
