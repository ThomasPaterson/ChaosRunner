using UnityEngine;
using System.Collections;

public class LaserMutation : Mutation
{
	public float offset = 10f;

	override public void RunMutation ()
	{

	}
	
	override public void StartMutation()
	{
		base.StartMutation ();

		foreach (PlayerState states in GameState.instance.players) 
		{
			Transform transform = states.transform;

			GameObject laser = (GameObject)Instantiate(Config.instance.laserReticule, transform.position, new Quaternion());
			laser.GetComponent<LaserReticule>().Init (transform);

			Vector3 laserStart = new Vector3(GameState.RandomSign()*offset, (Random.value+0.5f)*offset, 0f);
			GameObject beam = (GameObject)Instantiate(Config.instance.laserBeam, laserStart, new Quaternion());
			beam.GetComponent<LaserBeam>().Init (transform);
		}
    }
	
}
