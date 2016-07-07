using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerupManager : MonoBehaviour 
{
	public static PowerupManager instance;

	public enum PowerupType {TripleJump, Slash, AirControl, Speed, LowGrav};

	public List<PowerupType> availablePowerups;
	public List<PowerupType> currentPowerups;

	public int doubleJumps = 1;

	void Awake()
	{
		instance = this;
	}


	public void RecievePowerup()
	{
		AudioSource.PlayClipAtPoint (Config.instance.powerup, Camera.main.transform.position);

		if (availablePowerups.Count > 0) 
		{
			PowerupType type = availablePowerups[Mathf.FloorToInt(Random.Range(0, availablePowerups.Count))];
			ApplyPowerup(type);
			availablePowerups.Remove (type);
			currentPowerups.Add(type);
		}
	}

	void ApplyPowerup(PowerupType type)
	{

		switch (type) 
		{

		case PowerupType.AirControl:
			ApplyAirControl();
			PowerupDisplay.instance.DisplayPowerup("Air Skates!");
			break;
		case PowerupType.Slash:
			UnlockSlash();
			PowerupDisplay.instance.DisplayPowerup("Slash!");
			break;
		case PowerupType.TripleJump:
			doubleJumps++;
			PowerupDisplay.instance.DisplayPowerup("Triple Jump!");
			break;
		case PowerupType.Speed:
			ApplySpeed();
			PowerupDisplay.instance.DisplayPowerup("Speed!");
			break;
		case PowerupType.LowGrav:
			ApplyLowGrav();
			PowerupDisplay.instance.DisplayPowerup("Low Grav!");
			break;
		}
	}

	void ApplyAirControl()
	{
		foreach (PlayerState states in GameState.instance.players) 
			states.GetComponent<PlayerControls>().inAirDamping = Config.instance.airControlDamping;
	}

	void UnlockSlash()
	{
		foreach (PlayerState states in GameState.instance.players) 
			states.GetComponent<PlayerSlashControl>().Unlock();
	}

	void ApplySpeed()
	{
		foreach (PlayerState states in GameState.instance.players) 
			states.GetComponent<PlayerControls>().runSpeed = Config.instance.superSpeed;
	}

	void ApplyLowGrav()
	{
		foreach (PlayerState states in GameState.instance.players) 
			states.GetComponent<PlayerControls>().gravity = Config.instance.lowGrav;
	}


}
