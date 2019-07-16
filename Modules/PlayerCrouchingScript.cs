using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerCrouchingScript : MonoBehaviour {

	private CharacterController player;
	private FirstPersonController controller;
	public bool isCrouching;
	public bool canUncrouch;

	private float originalHeight;
	private float crouchingHeight;
	private Vector3 originalCenter;
	private Vector3 crouchingCenter;

	void Start () {
		player = GetComponent<CharacterController> ();
		controller = GetComponent<FirstPersonController> ();
		originalHeight = player.height;
		originalCenter = player.center;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			Crouch ();
		} else if (Input.GetKeyUp (KeyCode.LeftControl) && canUncrouch) {
			StopCrouching ();
		} else if (!Input.GetKey (KeyCode.LeftControl) && canUncrouch) {
			StopCrouching ();
		}

		//checks if anything is above you and preventing you from un-crouching
		RaycastHit hit;
		if (isCrouching && Physics.SphereCast (transform.position, .1f, Vector3.up, out hit, 1f)) {
			canUncrouch = false;
		} else {
			canUncrouch = true;
		}

		//how to quit the game. Yeah I know a bit out of place what w/e.
		if (Input.GetKey (KeyCode.Escape) && Input.GetKey (KeyCode.Q)) {
			Application.Quit ();
		}
	}

	void Crouch(){
		player.height *= .5f;
		player.center = new Vector3 (0f, -.45f, 0f);
		controller.m_WalkSpeed = 2f;
		isCrouching = true;
	}
	void StopCrouching(){
		player.height = originalHeight;
		player.center = originalCenter;
		controller.m_WalkSpeed = 4f;
		isCrouching = false;
	}
}
