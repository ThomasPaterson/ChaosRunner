using UnityEngine;
using System.Collections;

public class RenderingLayer 
{

	public enum Layer { Particle = 1};


	public static int GetLayer(Layer layer)
	{
		return (int) layer;
	}


}
	

