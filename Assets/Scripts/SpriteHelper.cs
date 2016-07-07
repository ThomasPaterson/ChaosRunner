using UnityEngine;
using System.Collections;


//used to manage sprite sizes, set layers to correct layer
//attach to resolution vulnerable stuff, mainly text
public class SpriteHelper : MonoBehaviour {

	public static float DEFAULT_RES_WIDTH = 1280.0f;
	public static float DEFAULT_RES_HEIGHT = 720.0f;

	public RenderingLayer.Layer layer;
	public bool setScale = false;
	public bool setLayer = true;

	// Use this for initialization
	void Awake () {
        SetLayer (layer);
		SetScale ();
	}

	public void SetLayer(RenderingLayer.Layer layer){
		if (renderer != null)
			renderer.sortingLayerID = RenderingLayer.GetLayer(layer);
	}

    public void SetSortingOrder(int order){
        if (renderer != null)
            renderer.sortingOrder = order;
    }

	private void SetScale()	{


		float defaultAspectRatio = DEFAULT_RES_WIDTH / DEFAULT_RES_HEIGHT;
		float aspectRatio = Camera.main.aspect;

		Vector3 currentScale = this.transform.localScale;
		
		currentScale.x = currentScale.x * ( aspectRatio / defaultAspectRatio );
		currentScale.y = currentScale.y * ( aspectRatio / defaultAspectRatio );
		
		this.transform.localScale = currentScale;
		
	}
}
