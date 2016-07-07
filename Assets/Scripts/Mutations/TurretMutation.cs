using UnityEngine;
using System.Collections;

public class TurretMutation : Mutation
{

	override public void RunMutation ()
	{

	}
	
	override public void StartMutation()
	{
		base.StartMutation ();
		TurretHolderInstance.instance.EnableTurrets ();

    }



}
