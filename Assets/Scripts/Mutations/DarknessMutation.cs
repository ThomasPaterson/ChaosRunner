using UnityEngine;
using System.Collections;

public class DarknessMutation : Mutation
{
	public GameObject darknessPrefab;

	override public void RunMutation ()
	{

	}
	
	override public void StartMutation()
	{
		base.StartMutation ();
		DarknessInstance.instance.ActivateDarkness ();

    }



}
