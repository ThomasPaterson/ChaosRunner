using UnityEngine;
using System.Collections;

public class CharacterCollider : MonoBehaviour 
{

	public virtual void FellOn(GameObject faller) {
		Debug.Log ("hit player");

	}
}
