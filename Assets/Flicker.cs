using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour 
{
	private int flickerFrames;
	private SpriteRenderer rend;

	void Awake()
	{
		rend = GetComponent<SpriteRenderer> ();
	}

	// Use this for initialization
	public void StartFlicker (int flickerFrames) {
		this.flickerFrames = flickerFrames;

		StartCoroutine (Flick ());
	}
	
	IEnumerator Flick()
	{
		while (flickerFrames-- > 0) {
			SetTransparency(Random.value);
			yield return null;
		}
		SetTransparency(1f);
	}

	void SetTransparency(float alpha)
	{
		Color color = rend.color;
		color.a = alpha;
		rend.color = color;
	}
}
