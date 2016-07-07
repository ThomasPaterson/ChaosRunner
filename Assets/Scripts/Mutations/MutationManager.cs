using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MutationManager : MonoBehaviour 
{
	public static MutationManager instance;
	
	public List<Mutation> availableMutations;

	public Mutation debug;
	
	public float iceDamping = 2f;
	public float windStrength = 3f;
	public float waterRiseRate = 3f;

	private List<Mutation> currentMutations;

	void Awake()
	{
		instance = this;
		currentMutations = new List<Mutation> ();
	}

	void Update()
	{
		foreach (Mutation mutation in currentMutations)
			mutation.RunMutation();
	}

	public void AddMutation()
	{
		if (debug != null) 
		{
			debug.StartMutation();
			availableMutations.Remove (debug);
			currentMutations.Add(debug);
			debug = null;
			AudioSource.PlayClipAtPoint(Config.instance.mutate, transform.position);
		}
		else if (availableMutations.Count > 0) 
		{
			Mutation mutation = availableMutations[Mathf.FloorToInt(Random.Range(0, availableMutations.Count))];
			mutation.StartMutation();
			availableMutations.Remove (mutation);
			currentMutations.Add(mutation);
			AudioSource.PlayClipAtPoint(Config.instance.mutate, transform.position);
		}

	}




}
