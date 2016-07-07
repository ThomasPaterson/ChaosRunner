using UnityEngine;
using System.Collections;

public class TurretAI : MonoBehaviour {

	public int framesToCharge = 120;
	public int framesToShoot = 120;
	public Vector3 shootOffset;
	public int framesToFlicker = 120;

	private int chargeShot;
	private Animator anim;
	private Vector3 target;
	private bool firing = false;


	void Awake()
	{
		anim = GetComponent<Animator> ();
		GetComponent<SpriteRenderer> ().enabled = false;
		collider2D.enabled = false;
		GetComponentInChildren<TurretDetector> ().collider2D.enabled = false;
	}

	public void StartTurret(){
		GetComponent<SpriteRenderer> ().enabled = true;
		collider2D.enabled = true;
		GetComponent<Flicker> ().StartFlicker (framesToFlicker);
		StartCoroutine (CountdownToDamage ());
	}

	public void ChargeShot(Transform player)
	{
		if (!firing) 
		{	
			chargeShot++;

			if (chargeShot > framesToCharge) 
			{
				target = player.position;
				StartCoroutine(Fire ());
			}
		}
	}

	IEnumerator Fire()
	{
		chargeShot = 0;
		anim.SetTrigger ("Attack");
		firing = true;

		int frames = 0;

		while (frames++ < framesToShoot)
			yield return null;


		GameObject projectile = (GameObject)Instantiate (Config.instance.turretProjectile, transform.position+shootOffset, new Quaternion ());
		projectile.GetComponent<Projectile> ().SetTrajectory (target, transform.position+shootOffset);
		firing = false;
		AudioSource.PlayClipAtPoint (Config.instance.turretFire, transform.position);

	}

	IEnumerator CountdownToDamage()
	{
		int frames = 0;
		
		while (frames++ < framesToFlicker)
			yield return null;
		
		GetComponentInChildren<TurretDetector> ().collider2D.enabled = true;
	}

}
