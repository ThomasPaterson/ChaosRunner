using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour 
{


	public static ColorManager instance;

	public List<Image> colorImages;
	public Text text;
	public Slider countdown;
	public Color blue;




	void Awake()
	{
		instance = this;
	}

	public void DisplayColors(List<DoorTrigger.ColorType> colors)
	{
		int indexToStart = colorImages.Count - colors.Count;

		for (int i = 0; i < indexToStart; i++)
			colorImages[i].enabled = false;

		for (int j = indexToStart; j < colorImages.Count; j++)
			SetToColor(colorImages[j], colors[j-indexToStart]);

		if (colors.Count == 0)
			text.enabled = true;
	}

	void SetToColor(Image image, DoorTrigger.ColorType colorType)
	{
		image.enabled = true;
		image.color = GetColorByType (colorType);
	}


	public static Color GetColorByType(DoorTrigger.ColorType colorType)
	{
		switch (colorType) 
		{
		case DoorTrigger.ColorType.Blue:
			return ColorManager.instance.blue;
		case DoorTrigger.ColorType.Green:
			return Color.green;
		case DoorTrigger.ColorType.Cyan:
			return Color.cyan;
		case DoorTrigger.ColorType.Red:
			return Color.red;
		case DoorTrigger.ColorType.Yellow:
			return Color.yellow;
		}

		return Color.white;
	}

	public void DisplayCountdown(float percent)
	{
		countdown.value = percent;
	}
}
