using UnityEngine;
using System.Collections;

public class Config : MonoBehaviour {

	public static Config instance;

	public GameObject tileDestroyParticles;
	public GameObject turretProjectile;
	public GameObject hailProjectile;
	public GameObject playerDeathParticles;
	public GameObject laserReticule;
	public GameObject laserBeam;
	public GameObject crescentSlash;
	public GameObject crescentParticles;
	public GameObject laserParticles;
	public GameObject spikeParticles;
	public GameObject turretParticles;
	public float airControlDamping = 10f;
	public float superSpeed = 11f;
	public float lowGrav = -20f;

	//Audio
	public AudioClip blockBreak;
	public AudioClip playerDeath;
	public AudioClip enemyDeath;
	public AudioClip groundJump;
	public AudioClip airJump;
	public AudioClip mutate;
	public AudioClip doorOpen;
	public AudioClip slash;
	public AudioClip turretFire;
	public AudioClip powerup;
	public AudioClip triggerHit;
	public AudioClip wind; 
	public AudioClip laserAmbient;
	public AudioClip laserLockon;


	void Awake()
	{
		
		if (instance == null) 
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}else
			Destroy (gameObject);
	}
}
