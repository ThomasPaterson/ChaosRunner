using UnityEngine;
using System.Collections;

public class PlayerNumberManager : MonoBehaviour {

	public static PlayerNumberManager instance;

	public int playerNum = 1;
	public bool takingTutorials = true;

	void Awake()
	{

		if (instance == null) 
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}else
			Destroy (gameObject);
	}


	public void SetPlayers(int playerNum)
	{
		this.playerNum = playerNum;
	}

	public void StartLevel()
	{
		if (takingTutorials)
			LevelManager.instance.LoadLevel(0);
		else
			LevelManager.instance.SkipTutorial();
	}
}
