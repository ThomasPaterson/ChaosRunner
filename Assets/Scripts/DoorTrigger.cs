using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour 
{
	private const float enabledAlpha = 0.8f;
	private const float disabledAlpha = 0.3f;

	public enum ColorType {Red, Green, Blue, Cyan, Yellow};

	public ColorType type;

	private bool activated = false;
	private SpriteRenderer spriteRenderer;

	void Awake(){
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == Tags.player) 
			if (DoorManager.instance.AttemptTrigger(this))
				SetForDestroy();

			
	}

	public bool Activated()
	{
		return activated;
	}

	public void SetActive(ColorType type)
	{
		Color color = spriteRenderer.color;

		if (this.type == type) {
			color.a = enabledAlpha;
			GetComponent<Animator> ().speed = 1f;

		}else{
			color.a = disabledAlpha;
			GetComponent<Animator> ().speed = 0.5f;
		}

		spriteRenderer.color = color;
	}

	void SetForDestroy()
	{
		collider2D.enabled = false;
		GetComponent<Animator> ().SetTrigger ("Triggered");
		GetComponent<DestroyAfterDelay> ().enabled = true;
		AudioSource.PlayClipAtPoint (Config.instance.triggerHit, transform.position);
	}

}
