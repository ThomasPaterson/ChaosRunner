using UnityEngine;
using System.Collections;

public class TurretDetector : MonoBehaviour {

	public TurretAI ai;

	void OnTriggerStay2D(Collider2D collider)
	{

		if (collider.tag == Tags.player) 
		{
			ai.ChargeShot(collider.transform);
		}
	}
}
