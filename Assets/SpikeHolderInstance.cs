using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpikeHolderInstance : MonoBehaviour {

	public static SpikeHolderInstance instance;

	private List<Spike> spikes;


	void Awake () {
		instance = this;
		spikes = new List<Spike> (GetComponentsInChildren<Spike> ());
	}

	public void EnableSpikes () {
	
		foreach (Spike s in spikes) 
			s.StartSpike();
			
	}
}
