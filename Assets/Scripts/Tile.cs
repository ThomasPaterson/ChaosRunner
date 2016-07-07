using UnityEngine;
using System.Collections;

public class Tile : CharacterCollider 
{
	public enum Type {Destructable, Indestructable, Damaging, Passable, Crumble};

	public Type type = Type.Destructable;

	private SpriteRenderer sRenderer;

	void Awake()
	{
		sRenderer = GetComponent<SpriteRenderer> ();
	}

	public override void FellOn(GameObject faller) {

		if (faller.tag == Tags.player) 
		{
			PlayerControls controls = faller.GetComponent<PlayerControls>();
			if (controls.PressingDown())
			{
				if (type == Type.Destructable || type == Type.Indestructable || type == Type.Crumble)
					controls.Bounce();

				if (type == Type.Destructable)
					DestroyTile ();
			}else
			{
				if (type == Type.Crumble)
				{
					controls.Bounce();
					DestroyTile ();
				}
			}
				
		}
		 	
	}

	public void DestroyTile()
	{
		Instantiate (Config.instance.tileDestroyParticles, transform.position, new Quaternion ());

		Color color = sRenderer.color;
		color.a = 0.22f;
		sRenderer.color = color;
		gameObject.collider2D.enabled = false;
		AudioSource.PlayClipAtPoint (Config.instance.blockBreak, gameObject.transform.position);

	}
	
}
