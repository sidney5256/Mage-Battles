using UnityEngine;
using System.Collections;

public class BladeBallAI : MonoBehaviour {

	public GameObject player;
	private Rigidbody rb;
	private float attackRate;
	private float nextAttackTime;

	void Awake(){
	}

	void Start () {
		rb = GetComponent<Rigidbody> ();
		attackRate = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextAttackTime) {
			StartCoroutine(DashToPlayer ());
			nextAttackTime = Time.time + attackRate;
		}
	}

	IEnumerator DashToPlayer(){
		transform.LookAt (player.transform.position);
		rb.velocity = transform.forward * 20f;
		yield return new WaitForSeconds (.75f);
		rb.velocity = Vector3.zero;
	}
}
