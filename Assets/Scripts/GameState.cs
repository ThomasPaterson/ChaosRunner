using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameState : MonoBehaviour 
{
	public static GameState instance;
	
	public List<PlayerState> players;
	public float windSpeed = 0f;

	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		if (players.Count > PlayerNumberManager.instance.playerNum) 
		{
			for (int i = players.Count-1; i >= PlayerNumberManager.instance.playerNum; i--)
			{
				Destroy(players[i].gameObject);
				players.RemoveAt(i);
			}
				
		}
	}

	public void ApplyIcy(float value)
	{
		foreach (PlayerState player in players)
			player.ChangeGroundDampening(value);
	}

	public void ApplyWind(float windSpeed)
	{
		this.windSpeed = windSpeed;
	}

	public void KillPlayer(GameObject player)
	{
		if (player.tag == Tags.player)
		{
			players.Remove(player.GetComponent<PlayerState>());
			Destroy(player);

			if (players.Count == 0)
				RestartLevel();
			else
			{
				Instantiate(Config.instance.playerDeathParticles, player.transform.position, new Quaternion());
				//AudioSource.PlayClipAtPoint(
			}

			AudioSource.PlayClipAtPoint(Config.instance.playerDeath, player.transform.position);
				
		}
	}

	void RestartLevel()
	{
		LevelManager.instance.RestartLevel ();
	}

	public static float RandomSign()
	{
		if (Random.value > 0.5f)
			return -1f;
		else
			return 1f;
	}
}
