using UnityEngine;
using System.Collections;

public class DarknessInstance : MonoBehaviour {

	public static DarknessInstance instance;

	public int framesToFade = 120; 

	private int fadeFrames;
	private SpriteRenderer sRenderer;

	void Awake()
	{
		instance = this;
		sRenderer=GetComponent<SpriteRenderer> ();
		sRenderer.enabled = false;
	}

	public void ActivateDarkness()
	{
		sRenderer.enabled = true;
		StartCoroutine (FadeIn ());
		fadeFrames = 0;
	}

	IEnumerator FadeIn()
	{
		while (fadeFrames++ < framesToFade) 
		{
			Color color = sRenderer.color;
			color.a = (((float)fadeFrames)/((float)framesToFade)-0.05f);
			sRenderer.color = color;
			
			yield return null;
		}
	}
}
