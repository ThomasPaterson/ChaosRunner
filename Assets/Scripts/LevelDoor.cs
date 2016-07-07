using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelDoor : MonoBehaviour 
{

	private bool locked = true;


	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == Tags.player) 
			if (!locked)
				LevelManager.instance.NextLevel();
	}

	public void Unlock()
	{
		locked = false;
		GetComponent<Animator> ().SetTrigger ("Open");
		AudioSource.PlayClipAtPoint (Config.instance.doorOpen, transform.position);
	}

}