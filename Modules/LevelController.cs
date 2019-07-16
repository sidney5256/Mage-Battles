using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {

	public List<GameObject> enemiesToKill = new List<GameObject>();
	public GameObject victoryPlatform;

	//assign the enemies in the inspector

	void Start(){
		victoryPlatform.SetActive (false);
	}

	void Update () {
		for (int i = 0; i < enemiesToKill.Count; i++) {
			if (enemiesToKill [i] == null) {
				//remove enemies that are dead from the list
				enemiesToKill.RemoveAt (i);
			}
		}
		if (enemiesToKill.Count == 0) {
			//if no more enemies in the level, active the portal
			victoryPlatform.SetActive (true);
		}
	}
}
