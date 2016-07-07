using UnityEngine;
using System.Collections;



public class SmoothFollow : MonoBehaviour
{
	public delegate void MoveCallback(Vector3 moved);
	public MoveCallback callback;


	public float smoothDampTime = 0.2f;
	[HideInInspector]
	public new Transform transform;
	public Vector3 cameraOffset;
	public bool useFixedUpdate = false;
	public float minSpread = 6f;
	public float maxSpread = 8f;
	
	private CharacterController2D _playerController;
	private Vector3 _smoothDampVelocity;
	
	
	void Awake()
	{
		transform = gameObject.transform;
	}
	
	
	void LateUpdate()
	{
		if( !useFixedUpdate )
			updateCameraPosition();
	}


	void FixedUpdate()
	{
		if( useFixedUpdate )
			updateCameraPosition();
	}


	void updateCameraPosition()
	{
		Bounds target = DetermineCameraBounds ();
		Vector3 temp = Vector3.SmoothDamp( transform.position, target.center, ref _smoothDampVelocity, smoothDampTime );
		temp.z = -10f;
		if (callback != null)
			callback(transform.position-temp);
		transform.position = temp;

		float targetCameraSize = DetermineCameraSize (target);
		Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, targetCameraSize, smoothDampTime);


	}

	Bounds DetermineCameraBounds()
	{
		float minX = float.MaxValue;
		float minY = float.MaxValue;
		float maxX = float.MinValue;
		float maxY = float.MinValue;

		foreach (PlayerState player in GameState.instance.players) 
		{
			Vector3 position = player.transform.position;

			if (position.x < minX)
				minX = position.x;
			if (position.x > maxX)
				maxX = position.x;
			if (position.y < minY)
				minY = position.y;
			if (position.y > maxY)
				maxY = position.y;
		}

		return new Bounds(
			new Vector3((maxX + minX)/2f, (maxY + minY)/2f, 0f),
			new Vector3((maxX - minX), (maxY - minY), 0f));
	}

	float DetermineCameraSize(Bounds target)
	{
		float cameraSpread = Vector3.Distance (target.max, target.min);

		if (cameraSpread > minSpread*2f)
			return Mathf.Clamp(Mathf.Log(cameraSpread/minSpread)*minSpread, minSpread, maxSpread);
		else
			return minSpread;
	}

	public void RegisterForMove(MoveCallback translateCallback){

		callback += translateCallback;
	}
	
}
