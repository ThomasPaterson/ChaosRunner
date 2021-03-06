﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerupDisplay : MonoBehaviour 
{
	public static PowerupDisplay instance;

	public int framesToFade = 120; 

	private Text text;
	private Image image;
	private int fadeFrames;
	private bool fading = false;

	void Awake()
	{
		instance = this;
		image = GetComponent<Image> ();
		text = GetComponentInChildren<Text> ();
	}

	public void DisplayPowerup(string displayString)
	{
		text.enabled = true;
		image.enabled = true;
		text.text = displayString;
		fadeFrames = framesToFade;

		if (!fading)
			StartCoroutine (Fade ());
	}

	IEnumerator Fade()
	{
		fading = true;

		while (fadeFrames-- > 0) 
		{
			Color textColor = text.color;
			textColor.a = ((float)fadeFrames)/((float)framesToFade);
			text.color = textColor;

			Color imageColor = image.color;
			imageColor.a = ((float)fadeFrames)/((float)framesToFade);
			image.color = imageColor;

			yield return null;
		}

		fading = false;
		text.enabled = false;
		image.enabled = false;
	}
}
