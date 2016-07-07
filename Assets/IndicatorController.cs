using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IndicatorController : MonoBehaviour {

	public static IndicatorController instance;

	private Transform target;
	private Image image;

	void Awake()
	{
		instance = this;
		image = GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (target == null)
			GetTarget();
		else if (WithinCamera(target))
			image.enabled = false;
		else
			DisplayTarget(target);
	
	}


	void GetTarget()
	{
		target = DoorManager.instance.GetNext ();
		GetComponent<Animator> ().SetTrigger ("NewDisplay");
		DisplayTarget (target);
		DisplayColor ();
	}

	bool WithinCamera(Transform target)
	{
		Vector2 cameraLoc = Camera.main.WorldToViewportPoint (target.position);
		if (cameraLoc.x > 0.97f || cameraLoc.x < 0.03f)
			return false;
		else if (cameraLoc.y > 0.97f || cameraLoc.y < 0.3f)
			return false;

		return true;
	}

	void DisplayTarget(Transform toDisplay)
	{
		image.enabled = true;

		RectTransform canvasRect = CanvasInstance.instance.rect;

		Vector2 ViewportPosition= Camera.main.WorldToViewportPoint(toDisplay.position);


		ViewportPosition.x = Mathf.Clamp (ViewportPosition.x, 0.05f, 0.95f);
		ViewportPosition.y = Mathf.Clamp (ViewportPosition.y, 0.06f, 0.93f);

		Vector2 WorldObject_ScreenPosition=new Vector2(
			((ViewportPosition.x*canvasRect.sizeDelta.x)-(canvasRect.sizeDelta.x*0.5f)),
			((ViewportPosition.y*canvasRect.sizeDelta.y)-(canvasRect.sizeDelta.y*0.5f)));
		
	
		image.rectTransform.anchoredPosition=WorldObject_ScreenPosition;

    }

	void DisplayColor()
	{
		if (target.GetComponent<DoorTrigger> () != null)
			image.color = ColorManager.GetColorByType (target.GetComponent<DoorTrigger> ().type);
		else
			image.color = Color.white;
	}
}
