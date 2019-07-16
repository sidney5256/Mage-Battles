using UnityEngine;
using System.Collections;

public class CameraCrouchScript : MonoBehaviour {

	private PlayerCrouchingScript script;
	private Vector3 originalPos;
	private Vector3 targetPos;
	private Vector3 vel = Vector3.zero;

	void Start () {
		script = GetComponentInParent<PlayerCrouchingScript> ();
		originalPos = transform.localPosition;
		targetPos = new Vector3 (0f, -.1f, 0f);
	}

	void Update () {

		//lowers camera to match crouching height. Head bob must be OFF for smooth movement to work.
		if (script.isCrouching) {
			transform.localPosition = Vector3.SmoothDamp(transform.localPosition, targetPos, ref vel, .1f);
		} else if (!script.isCrouching) {
			transform.localPosition = Vector3.SmoothDamp(transform.localPosition, originalPos, ref vel, .1f);
		}
	}
}
