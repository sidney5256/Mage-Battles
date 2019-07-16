using UnityEngine;
using System.Collections;

public class SpinScript : MonoBehaviour {

	public float spinSpeed;
	private Rigidbody rb;

	void Start () { //just makes stuff spin
		spinSpeed = 10f;
		rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Vector3.up * spinSpeed;
	}

	void Update () {
		
	}
}
