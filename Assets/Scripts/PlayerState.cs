using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour 
{
	private PlayerControls _controls;

	void Awake()
	{
		_controls = GetComponent<PlayerControls> ();
	}

	public void ChangeGroundDampening(float newValue)
	{
		_controls.groundDamping = newValue;
	}
}
