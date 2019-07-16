using UnityEngine;
using System.Collections;

public class PaladinAttackBox : MonoBehaviour {

	public GameObject paladin;
	private PaladinAI paladinAI;

	void Start(){
		paladinAI = paladin.GetComponent<PaladinAI> ();
	}
	void OnTriggerStay(Collider other){
		if (other.CompareTag ("Player")) {
			paladinAI.currentState.OnTriggerStay ();
		}
	}

}
