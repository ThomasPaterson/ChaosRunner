using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {
	
	public static LevelManager instance;
	private const int NUM_BEFORE_SWITCH = 2;
	
	public List<string> levelNames;
	public string menu;
	public List<AudioClip> songs;

	private int left = 0;

	void Awake()
	{
		
		if (instance == null) 
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
			PlaySong();
		}else
			Destroy (gameObject);
	}

	public void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevelName);
	}
	
	public void LoadLevel(int index)
	{
		PlaySong ();
		Application.LoadLevel (levelNames [index]);
	}
	
	public void NextLevel()
	{
		PlaySong ();
		int index = levelNames.IndexOf (Application.loadedLevelName);

		if (index < levelNames.Count-1)
			Application.LoadLevel (levelNames[index+1]);
		else
			Application.LoadLevel(menu);
	}

	public void SkipTutorial()
	{
		LoadLevel (5);
	}

	public void PlaySong()
	{
		if (left <= 0) {

			audio.Stop ();
			audio.clip = songs[Mathf.FloorToInt(Random.Range(0, songs.Count))];
			audio.Play ();
			left= NUM_BEFORE_SWITCH;
		}else
			left--;

	}
}
