using UnityEngine;
using System.Collections;

public class HailMutation : Mutation
{

	override public void RunMutation ()
	{

	}
	
	override public void StartMutation()
	{
		base.StartMutation ();
		HailHolderInstance.instance.EnableHailers ();

    }



}
