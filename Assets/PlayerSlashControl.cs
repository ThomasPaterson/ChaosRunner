using UnityEngine;
using System.Collections;

public class PlayerSlashControl : MonoBehaviour 
{

	public int slashCooldown;
	public Vector3 offset;

	private int cooldown;
	private bool unlocked = false;
	private bool slashReady = false;

	void Start()
	{
		cooldown = 0;
		slashReady = false;
	}

	void Update()
	{
		if (cooldown < slashCooldown)
			cooldown++;
		else
			slashReady = true;
	
	}

	public void Slash(float xVelocity)
	{
		if (unlocked && slashReady) 
		{
			CreateSlash(xVelocity);
			cooldown = 0;
			slashReady = false;
		}
	}

	void CreateSlash(float xVelocity)
	{
		Vector3 pos = transform.position + offset * Mathf.Sign (transform.localScale.x);
		GameObject slash = (GameObject)Instantiate (Config.instance.crescentSlash, pos, new Quaternion ());
		slash.GetComponent<SlashController> ().Init (transform, xVelocity, Mathf.Sign (transform.localScale.x));
		AudioSource.PlayClipAtPoint (Config.instance.slash, transform.position);
	}

	public void Unlock()
	{
		unlocked = true;
	}

}
