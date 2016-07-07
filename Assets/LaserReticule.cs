using UnityEngine;
using System.Collections;

public class LaserReticule : MonoBehaviour {

	private Transform player;

	public void Init(Transform player)
	{
		this.player = player;
		AudioSource.PlayClipAtPoint (Config.instance.laserLockon, player.position);
	}

	void LateUpdate()
	{
		if (player != null)
			transform.position = player.position;
		else
			Destroy (gameObject);
	}

}
