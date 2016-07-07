using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasInstance : MonoBehaviour {

	public static CanvasInstance instance;

	public Canvas canvas;
	public RectTransform rect;

	void Awake(){

		instance = this;
		canvas = GetComponent<Canvas> ();
		rect = GetComponent<RectTransform> ();
	}

}
