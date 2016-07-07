using UnityEngine;
using System.Collections;

public class SlashController : MonoBehaviour 
{

	public float speed;

	private Transform parent;
	private Vector2 velocity;


	public void Init(Transform attacker, float inheritedXVel, float sign)
	{
		parent = attacker;
		velocity = new Vector2 (inheritedXVel*Time.deltaTime + sign * speed, 0f);

		transform.localScale = new Vector3( transform.localScale.x*sign, transform.localScale.y, transform.localScale.z ); 
	}

	void FixedUpdate()
	{
		rigidbody2D.MovePosition (new Vector2 (transform.position.x, transform.position.y) + velocity);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == Tags.player && collider.transform != parent) {
			GameState.instance.KillPlayer(collider.gameObject);
			Destroy(gameObject);
			Instantiate(Config.instance.crescentParticles, transform.position, new Quaternion());
		}else if (collider.gameObject.GetComponent<Tile>() != null)
			CollideWithTile(collider.gameObject);
		else if (collider.gameObject.GetComponent<TurretAI>() != null)
		{
			Destroy(collider.gameObject);
			Instantiate(Config.instance.turretParticles, collider.transform.position, new Quaternion());
			AudioSource.PlayClipAtPoint(Config.instance.enemyDeath, collider.gameObject.transform.position);
		}else if (collider.gameObject.GetComponent<Spike>() != null)
		{
			Destroy(collider.gameObject);
			Instantiate(Config.instance.spikeParticles, collider.transform.position, new Quaternion());
			AudioSource.PlayClipAtPoint(Config.instance.enemyDeath, collider.gameObject.transform.position);
		}
			
			

		
	}
	
	void CollideWithTile(GameObject o)
	{
		Tile tile = o.GetComponent<Tile> ();
		
		if (tile.type == Tile.Type.Destructable || tile.type == Tile.Type.Indestructable) {
			Instantiate(Config.instance.crescentParticles, transform.position, new Quaternion());
			Destroy (gameObject);
		}
			
		
		if (tile.type == Tile.Type.Destructable)
			tile.DestroyTile();
	}
}
