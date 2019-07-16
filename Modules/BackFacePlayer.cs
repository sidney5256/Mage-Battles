using UnityEngine;
using System.Collections;

public class BackFacePlayer : MonoBehaviour {

	public Transform player;
	public bool notBack;
	
	void Awake(){

	}

	void Update () {
		if (player == null) {
			player = GetComponentInParent<EnemyStatesAI> ().player.transform;
		} else {
			if (!notBack) {
				transform.LookAt (player.position);
				transform.Rotate (new Vector3 (0f, 180f, 0f));
			} else {
				transform.LookAt (player.position);
			}
		}
	}
}
