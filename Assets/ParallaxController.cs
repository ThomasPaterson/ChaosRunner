using UnityEngine;
using System.Collections;

public class ParallaxController : MonoBehaviour {

	public float parallaxAmount  = 0.5f;
	// Use this for initialization
	void Start () {
		Camera.main.GetComponent<SmoothFollow> ().RegisterForMove (Translate);
	}
	
	void Translate(Vector3 move)
	{
		Vector3 temp = transform.position + move * parallaxAmount;
		transform.position = new Vector3(temp.x, transform.position.y, 0f);
	}
}
