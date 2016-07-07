using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	public int numPlayers;

	public void Trigger()
	{
		PlayerNumberManager.instance.SetPlayers (numPlayers);
		PlayerNumberManager.instance.StartLevel ();
	}
}
