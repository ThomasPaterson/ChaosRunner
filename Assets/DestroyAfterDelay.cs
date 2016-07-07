using UnityEngine;
using System.Collections;

public class DestroyAfterDelay : MonoBehaviour {

	public int framesToWait = 180;

	// Update is called once per frame
	void Update () {
		if (framesToWait-- <= 0)
			Destroy(gameObject);
	}
}
