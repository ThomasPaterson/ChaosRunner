using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ExtensionMethods 
{

    public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex) 
    {
        if (firstIndex == secondIndex) 
            return;

        T temp = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = temp;
    }

    public static void SetByWorldSpace(this RectTransform toSet, RectTransform canvas, Vector3 worldSpace, Camera cam) 
    {

        Vector2 ViewportPosition=cam.WorldToViewportPoint(worldSpace);

        Vector2 WorldObject_ScreenPosition=new Vector2(
            ((ViewportPosition.x*canvas.sizeDelta.x)-(canvas.sizeDelta.x*0.5f)),
            ((ViewportPosition.y*canvas.sizeDelta.y)-(canvas.sizeDelta.y*0.5f)));
        

        toSet.anchoredPosition=WorldObject_ScreenPosition;
    } 
	public static Vector3 GetWorldSpace(this RectTransform toGet, RectTransform canvas, Camera cam) 
	{
		
		Vector2 screenPos = new Vector2(
			(toGet.anchoredPosition.x + (canvas.sizeDelta.x*0.5f))/canvas.sizeDelta.x,
			 (toGet.anchoredPosition.y + (canvas.sizeDelta.y*0.5f))/canvas.sizeDelta.y);
		
		
		return cam.ViewportToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0f));
	}

	public static void Shuffle<T>(this IList<T> list)  
	{  
		int n = list.Count;  
		while (n > 1) {  
			n--;  
			int k = Mathf.FloorToInt(Random.Range(0, n + 1));  
			T value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
	}

}
