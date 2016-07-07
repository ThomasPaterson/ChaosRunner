using UnityEngine;
using System.Collections;

public class SpikeMutation : Mutation
{

	override public void RunMutation ()
	{

	}
	
	override public void StartMutation()
	{
		base.StartMutation ();
		SpikeHolderInstance.instance.EnableSpikes ();

    }



}
