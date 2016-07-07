using UnityEngine;
using System.Collections;

public class IcyMutation : Mutation
{
	public float icyDampening = 2f;

	override public void RunMutation ()
	{

	}
	
	override public void StartMutation()
	{
		base.StartMutation ();
		GameState.instance.ApplyIcy (icyDampening);
    }
	
}
