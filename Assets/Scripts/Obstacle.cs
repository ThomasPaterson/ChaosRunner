using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == Tags.player) 
		{
			GameState.instance.KillPlayer(collider.gameObject);
		}
		
	}
}
