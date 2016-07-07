using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {
	
	public int framesToFlicker = 120;
	// Use this for initialization

	void Awake()
	{
		GetComponent<SpriteRenderer> ().enabled = false;
		collider2D.enabled = false;
	}

	public void StartSpike () {
		GetComponent<SpriteRenderer> ().enabled = true;
		GetComponent<Flicker> ().StartFlicker (framesToFlicker);
		StartCoroutine (CountdownToDamage ());
	}
	
	IEnumerator CountdownToDamage()
	{
		int frames = 0;

		while (frames++ < framesToFlicker)
			yield return null;

		collider2D.enabled = true;
	}
}
