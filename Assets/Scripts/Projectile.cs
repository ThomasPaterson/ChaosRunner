using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed;

	private Vector3 direction;

	public void SetTrajectory(Vector3 target, Vector3 currentLoc)
	{
		direction = Vector3.Normalize (target - currentLoc);
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = new Vector2 (direction.x * speed, direction.y * speed);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == Tags.player) {
			GameState.instance.KillPlayer(collider.gameObject);
			Destroy(gameObject);
			Instantiate(Config.instance.spikeParticles, collider.transform.position, new Quaternion());
		}else if (collider.gameObject.GetComponent<Tile>() != null)
			CollideWithTile(collider.gameObject);
		
	}

	void CollideWithTile(GameObject o)
	{
		Tile tile = o.GetComponent<Tile> ();

		if (tile.type == Tile.Type.Destructable || tile.type == Tile.Type.Indestructable) 
		{
			Instantiate(Config.instance.crescentParticles, transform.position, new Quaternion());
			Destroy (gameObject);
		}
			

		if (tile.type == Tile.Type.Destructable)
			tile.DestroyTile();
	}
}
