using UnityEngine;
using System.Collections;

public class PaladinMeleeState : IPaladinStates {
	
	public PaladinAI paladin;

	private float fireRate = 1.5f;
	private float nextFireTime;

	private Vector3 direction;
	private Quaternion lookRotation;

	public PaladinMeleeState(PaladinAI p){
		paladin = p;
	}
	public void UpdateState (){
		Chase ();
		if (Time.time > paladin.nextStateTime) {
			ToPreRangedState ();
		}
	}
	public void OnTriggerStay (){ //This will be called when player enters its attack box trigger.
		if (Time.time > nextFireTime) {
			paladin.MeleeAttackPre ();
			nextFireTime = Time.time + fireRate;
		}
	}
	public void ToMeleeState (){

	}

	public void ToPreRangedState(){
		paladin.nextStateTime = Time.time + 5f;
		paladin.nav.Stop ();
		paladin.currentState = paladin.preRangedState;

		//play the "charging up my laser" sound;
		paladin.source.clip = paladin.charge;
		paladin.source.Play ();

	}

	public void ToRangedState (){

	}
	private void Chase(){
		paladin.nav.destination = paladin.player.transform.position;
		paladin.nav.Resume(); 

		//make paladin look at player smoothly
		direction = (paladin.player.transform.position - paladin.gameObject.transform.position).normalized;
		lookRotation = Quaternion.LookRotation (direction);
		paladin.gameObject.transform.rotation = Quaternion.Slerp (paladin.gameObject.transform.rotation, lookRotation, Time.deltaTime * 5f);
	}
}
