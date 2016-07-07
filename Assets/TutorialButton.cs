using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour {

	private Image image;

	void Awake()
	{
		image = GetComponent<Image> ();
	}

	public void Trigger()
	{
		PlayerNumberManager.instance.takingTutorials = !PlayerNumberManager.instance.takingTutorials;
	}

	void Update()
	{
		if (PlayerNumberManager.instance.takingTutorials)
			SetTransparency(1f);
		else
			SetTransparency(0.35f);
	}

	void SetTransparency(float value)
	{
		Color c = image.color;
		c.a = value;
		image.color = c;
	}
}
