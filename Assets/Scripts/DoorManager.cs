using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorManager : MonoBehaviour 
{
	public static DoorManager instance;

	public float timeToSwitch = 120;
	
	private List<DoorTrigger> triggers;
	private List<LevelDoor> doors;
	private List<DoorTrigger.ColorType> colors;
	private float countdown;

	void Awake()
	{
		instance = this;
		triggers = new List<DoorTrigger> (GetComponentsInChildren<DoorTrigger> ());
		doors = new List<LevelDoor> (GetComponentsInChildren<LevelDoor> ());
		GenerateColors ();
		colors.Shuffle<DoorTrigger.ColorType> ();
		countdown = timeToSwitch;
	}

	void Start()
	{
		ColorManager.instance.DisplayColors (colors);
		DisplayEnabled ();
	}

	void Update()
	{
		countdown -= Time.deltaTime;

		if (countdown <= 0) 
		{
			countdown = timeToSwitch;
			MutationManager.instance.AddMutation();
			DisplayEnabled();
		}

		ColorManager.instance.DisplayCountdown (countdown / timeToSwitch);
	}

	void GenerateColors()
	{
		colors = new List<DoorTrigger.ColorType> ();

		foreach(DoorTrigger trigger in triggers)
			if (!colors.Contains(trigger.type))
				colors.Add(trigger.type);
	}

	public bool AttemptTrigger(DoorTrigger trigger)	
	{
		if (colors.Count > 0 && colors [0] == trigger.type) 
		{
			triggers.Remove(trigger);
			colors.Remove(trigger.type);
			AttemptUnlockDoors();
			ColorManager.instance.DisplayColors (colors);
			DisplayEnabled();
			return true;
		}

		return false;
	}

	void AttemptUnlockDoors()
	{
		if (triggers.Count <= 0)
			foreach (LevelDoor door in doors)
				door.Unlock();
	}

	void DisplayEnabled()
	{
		foreach (DoorTrigger trigger in triggers)
			trigger.SetActive(colors[0]);
	}

	public Transform GetNext()
	{
		if (triggers.Count > 0) 
		{
			foreach(DoorTrigger trigger in triggers)
				if (trigger.type == colors[0])
					return trigger.transform;

		}
			
		return doors[0].transform;
	}
}
