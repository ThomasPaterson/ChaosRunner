using UnityEngine;
using System.Collections;


public class PlayerControls : MonoBehaviour
{
	// movement config
	public float gravity = -25f;
	public float runSpeed = 8f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float jumpHeight = 3f;
	public float doubleJumpHeight = 1.5f;
	public float airborneWindMultiplier = 1.5f;
	public string controlNum = "1";
	public int pressedDownFrames = 10;

	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;

	private CharacterController2D _controller;
	private PlayerSlashControl slashControls;
	private Animator _animator;
	private RaycastHit2D _lastControllerColliderHit;
	private Vector3 _velocity;
	private int doubleJumps = 0;
	private bool bounced = false;
	private int downFrames = 0;




	void Awake()
	{
		_animator = GetComponent<Animator>();
		_controller = GetComponent<CharacterController2D>();
		slashControls = GetComponent<PlayerSlashControl> ();

		// listen to some events for illustration purposes
		_controller.onControllerCollidedEvent += onControllerCollider;
		_controller.onTriggerEnterEvent += onTriggerEnterEvent;
		_controller.onTriggerExitEvent += onTriggerExitEvent;
	}


	#region Event Listeners

	void onControllerCollider( RaycastHit2D hit )
	{
		// bail out on plain old ground hits cause they arent very interesting
		if( hit.normal.y == 1f )
			return;

		// logs any collider hits if uncommented. it gets noisy so it is commented out for the demo
		//Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
	}


	void onTriggerEnterEvent( Collider2D col )
	{
	}


	void onTriggerExitEvent( Collider2D col )
	{
	}

	#endregion


	// the Update loop contains a very simple example of moving the character around and controlling the animation
	void Update()
	{
		// grab our current _velocity to use as a base for all calculations
		_velocity = _controller.velocity;
		_controller.pressedDown = false;

		if (_controller.isGrounded) 
		{
			_velocity.y = 0;
			doubleJumps = 0;
			_velocity.x += GameState.instance.windSpeed;
		}else
		{
			_velocity.x += GameState.instance.windSpeed * airborneWindMultiplier;
		}
			

		if( Input.GetButton("Right" + controlNum) )
		{
			normalizedHorizontalSpeed = 1;
			if( transform.localScale.x < 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );

			if( _controller.isGrounded )
				_animator.Play( Animator.StringToHash( "Run" ) );
		}
		else if( Input.GetButton("Left" + controlNum) )
		{
			normalizedHorizontalSpeed = -1;
			if( transform.localScale.x > 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );

			if( _controller.isGrounded )
				_animator.Play( Animator.StringToHash( "Run" ) );
		}
		else
		{
			normalizedHorizontalSpeed = 0;

			if( _controller.isGrounded )
				_animator.Play( Animator.StringToHash( "Idle" ) );
		}


		// we can only jump whilst grounded
		if(( _controller.isGrounded && Input.GetButton("Jump" + controlNum)) || bounced)
		{
			_velocity.y = Mathf.Sqrt( 2f * jumpHeight * -gravity );
			_animator.Play( Animator.StringToHash( "Jump" ) );
			bounced = false;
			AudioSource.PlayClipAtPoint(Config.instance.groundJump, transform.position);
		
		}else if( PowerupManager.instance.doubleJumps > doubleJumps && !_controller.isGrounded && Input.GetButtonDown("Jump" + controlNum) )
		{
			_velocity.y = Mathf.Sqrt( 2f * doubleJumpHeight * -gravity );
			_animator.Play( Animator.StringToHash( "Jump" ) );
			doubleJumps++;
			AudioSource.PlayClipAtPoint(Config.instance.airJump, transform.position);
			
		}else if(Input.GetButtonDown("Down" + controlNum) )

		{
			_controller.pressedDown = true;
			_velocity.y = -Mathf.Sqrt( 2f * doubleJumpHeight * -gravity );
			doubleJumps++;
			
		}

		if (Input.GetButton("Down" + controlNum))
			downFrames = pressedDownFrames;
		else if (downFrames > 0)
			downFrames--;


		// apply horizontal speed smoothing it
		var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
		_velocity.x = Mathf.Lerp( _velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor );

		if (Input.GetButtonDown("Fire" + controlNum))
			slashControls.Slash(_controller.velocity.x);

		// apply gravity before moving
		_velocity.y += gravity * Time.deltaTime;

		_controller.move( _velocity * Time.deltaTime );
	}

	public bool PressingDown()
	{
		if (downFrames > 0) 
		{
			downFrames = 0;
			return true;
		}
		return false;
	}

	public void Bounce()
	{
		bounced = true;
	}

}
