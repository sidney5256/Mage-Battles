using UnityEngine;
using System.Collections;

public class ArcherDudeScript : MonoBehaviour {

	public float fireRate = 2f;
	private float nextFireTime;
	private float dist;
	private EnemyStatesAI state;
	private PlayerCrouchingScript crouchingScript;
	public Transform player;
	public Transform crossbow;
	public GameObject arrow;
	public AudioClip sound;
	private AudioSource source;

	void Awake(){

	}

	void Start () {
		// if player was not assigned in the inspector, take it from EnemyStatesAI instead
		if (player == null) {
			player = GetComponent<EnemyStatesAI> ().player.transform;
		}

		state = GetComponent<EnemyStatesAI> ();
		crouchingScript = player.GetComponent<PlayerCrouchingScript> ();
		source = GetComponent<AudioSource> ();
		source.clip = sound;
	}

	void Update () {

		if (state.currentState == state.engageState && player != null){
			if (crouchingScript.isCrouching) {
				crossbow.LookAt (player.position);
			} else {
				crossbow.LookAt(new Vector3 (player.transform.position.x, player.transform.position.y + .7f, player.transform.position.z));
			}
			if (Time.time > nextFireTime) {
				ShootArrow ();
			}
		}
	}

	void ShootArrow(){
		source.Play ();
		Instantiate (arrow, crossbow.position, crossbow.rotation);
		nextFireTime = Time.time + fireRate;
	}
}
