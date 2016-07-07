using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretHolderInstance : MonoBehaviour {

	public static TurretHolderInstance instance;

	private List<TurretAI> turrets;


	void Awake () {
		instance = this;
		turrets = new List<TurretAI> (GetComponentsInChildren<TurretAI> ());
	}

	public void EnableTurrets () {
	
		foreach (TurretAI t in turrets) 
			t.StartTurret();
			
	}
}
