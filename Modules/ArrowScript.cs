using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

	public float force;
	public float damage;
	public GameObject destroyThis;
	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (transform.forward * force); 
	}
	void OnTriggerEnter(Collider other){
		if (!other.isTrigger){
			if (other.CompareTag ("Player")) {
				PlayerStats.stats.TakeDamage (damage);
			}
			transform.DetachChildren ();
			if (destroyThis != null) {
				Destroy (destroyThis);
			}
			Destroy (gameObject);
		}
	}

}
