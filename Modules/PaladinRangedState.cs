using UnityEngine;
using System.Collections;

public class PaladinRangedState : IPaladinStates {

	public PaladinAI paladin;
	private float fireRate = .333f;
	private float nextFireTime;

	private Vector3 direction;
	private Quaternion lookRotation;

	public PaladinRangedState(PaladinAI p){
		paladin = p;
	}
	public void UpdateState (){
		if (Time.time > nextFireTime) {
			paladin.RangedAttackPre ();
			nextFireTime = Time.time + fireRate;
		}
		if (Time.time > paladin.nextStateTime) {
			ToMeleeState ();
		}

		//make paladin look at player smoothly
		direction = (paladin.player.transform.position - paladin.gameObject.transform.position).normalized;
		lookRotation = Quaternion.LookRotation (direction);
		paladin.gameObject.transform.rotation = Quaternion.Slerp (paladin.gameObject.transform.rotation, lookRotation, Time.deltaTime * 5f);
	}
	public void OnTriggerStay (){

	}
	public void ToMeleeState (){
		paladin.nextStateTime = Time.time + 20f;
		paladin.nav.Resume ();
		paladin.currentState = paladin.meleeState;
	}
	public void ToRangedState (){

	}
	public void ToPreRangedState(){

	}
}
