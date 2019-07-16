using UnityEngine;
using System.Collections;

public class PaladinPreRangedState : IPaladinStates {

	public PaladinAI paladin;

	public PaladinPreRangedState(PaladinAI p){
		paladin = p;
	}
	public void UpdateState (){
		if (Time.time > paladin.nextStateTime) {
			ToRangedState ();
		}
	}

	public void OnTriggerStay (){

	}
	public void ToMeleeState (){

	}
	public void ToRangedState (){
		paladin.nextStateTime = Time.time + 5f;
		paladin.nav.Stop ();
		paladin.currentState = paladin.rangedState;

	}
	public void ToPreRangedState(){

	}
}
