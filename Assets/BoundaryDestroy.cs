using UnityEngine;
using System.Collections;

public class BoundaryDestroy : MonoBehaviour {

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == Tags.player)
			GameState.instance.KillPlayer(collider.gameObject);
		else 
			Destroy (collider.gameObject);
		
	}
}
