using UnityEngine;
using System.Collections;

public class WindMutation : Mutation
{
	public float maxWindSpeed;
	public float averageWindTime;
	public float changeRate = 5f;

	private float targetSpeed;
	private float currentSpeed;
	private float currentWindTime;

	override public void RunMutation ()
	{
		currentSpeed = Mathf.Lerp (currentSpeed, targetSpeed, changeRate * Time.deltaTime);
		GameState.instance.ApplyWind (currentSpeed);
		WindParticle.instance.SetWind (new Vector3 (currentSpeed, Random.value, 0f));
		currentWindTime -= Time.fixedDeltaTime;

		if (currentWindTime <= 0f) 
		{
			SetWindTime ();
			RandomizeWind ();
		}
	}
	
	override public void StartMutation()
	{
		base.StartMutation ();

		currentSpeed = 0f;
		WindParticle.instance.ActivateWind ();
		SetWindTime ();
		RandomizeWind ();
		AudioSource.PlayClipAtPoint (Config.instance.wind, Camera.main.transform.position);
    }

	float RandomDirection()
	{
		if (Random.value < 0.5f)
			return -1f;
		else
			return 1f;
	}

	void RandomizeWind()
	{
		targetSpeed =  maxWindSpeed * RandomDirection ();
	}

	void SetWindTime()
	{
		currentWindTime = averageWindTime * (Random.value + 0.5f);
	}
}
