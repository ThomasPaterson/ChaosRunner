using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

	public float speed;
	public int framesToArm = 120;
	public int framesToSpark = 15;

	private Transform player;
	private bool initialized = false;
	private int frames = 0;
	private int sparkFrames = 0;

	public void Init(Transform player)
	{
		this.player = player;
		initialized = true;
		GetComponent<Flicker> ().StartFlicker (framesToArm);
	}

	void LateUpdate () 
	{
    	if (frames < framesToArm)
			frames++;

		if (sparkFrames < framesToSpark)
			sparkFrames++;
		else
			Spark();

		if (player != null)
			MoveTowardsPlayer();
		else if (initialized)
			Destroy (gameObject);

	}

	void MoveTowardsPlayer()
	{
		Vector3 velocity = Vector3.Normalize (player.position - transform.position) * speed;
		transform.position += velocity;

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (frames >= framesToArm) 
		{
			if (collider.gameObject.tag == Tags.player) 
				GameState.instance.KillPlayer(collider.gameObject);
			else if (collider.gameObject.GetComponent<Tile>() != null)
				CollideWithTile(collider.gameObject);
		}
		
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if (frames >= framesToArm) 
		{
			if (collider.gameObject.tag == Tags.player) 
				GameState.instance.KillPlayer(collider.gameObject);
			else if (collider.gameObject.GetComponent<Tile>() != null)
				CollideWithTile(collider.gameObject);
		}
		
	}
	
	void CollideWithTile(GameObject o)
	{
		Tile tile = o.GetComponent<Tile> ();
		
		if (tile.type == Tile.Type.Destructable)
			tile.DestroyTile();
	}

	void Spark(){

		sparkFrames = 0;
		Instantiate(Config.instance.laserParticles, transform.position, new Quaternion());
	}
}
