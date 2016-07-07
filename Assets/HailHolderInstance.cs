using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HailHolderInstance : MonoBehaviour {

	public static HailHolderInstance instance;

	private List<HailSpawner> hailers;

	void Awake()
	{
		instance = this;
		hailers = new List<HailSpawner>(GetComponentsInChildren<HailSpawner> ());
	}

	public void EnableHailers()
	{
		foreach (HailSpawner hailer in hailers)
			hailer.EnableHailing();
	}
}
