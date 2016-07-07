using UnityEngine;
using System.Collections;

public class WindParticle : MonoBehaviour 
{

	public static WindParticle instance;

	void Awake()
	{
		instance = this;
		particleSystem.enableEmission = false;
	}

	public void ActivateWind()
	{
		particleSystem.enableEmission = true;
	}

	public void SetWind(Vector3 velocity)
	{
		Quaternion rotation = transform.rotation;

		if (velocity.x < 0)
			rotation.Set(0f, 0f, 180f, 0f);
		else
			rotation.Set(0f, 0f, 0f, 0f);

		transform.rotation = rotation;
	}
}
