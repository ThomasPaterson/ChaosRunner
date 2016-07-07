using UnityEngine;
using System.Collections;

public class HailSpawner : MonoBehaviour {

	public float hailRate = 120f;

	private bool hailing = false;
	private int frame = 0;

	void Update()
	{

		if (hailing) 
		{
			frame++;

			if (frame > hailRate)
				Hail();
		}
	}

	void Hail()
	{
		frame = 0;

		GameObject hail = (GameObject)Instantiate(Config.instance.hailProjectile, DetermineSpawnVector(), new Quaternion());
		hail.GetComponent<Projectile> ().SetTrajectory (Vector3.down, Vector3.zero);
	}

	Vector3 DetermineSpawnVector()
	{
		float xBound = collider2D.bounds.size.x;

		return new Vector3 ((xBound * Random.value - xBound / 2f) + transform.position.x, transform.position.y, 0f);

	}

	public void EnableHailing()
	{
		hailing = true;
	}
}
