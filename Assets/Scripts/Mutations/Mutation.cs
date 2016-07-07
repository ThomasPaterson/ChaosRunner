using UnityEngine;
using System.Collections;

[System.Serializable]
abstract public class Mutation : ScriptableObject
{

	abstract public void RunMutation ();

	public string mutationName;

	virtual public void StartMutation()
	{
		MutationDisplay.instance.DisplayMutation (mutationName);
	}
	
}
