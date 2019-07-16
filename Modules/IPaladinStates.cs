using UnityEngine;
using System.Collections;

public interface IPaladinStates{

	void UpdateState ();
	void OnTriggerStay ();
	void ToMeleeState ();
	void ToPreRangedState();
	void ToRangedState ();

}
