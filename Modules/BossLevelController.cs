using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossLevelController : MonoBehaviour {

	public GameObject Boss;
	public List<GameObject> activateTheseThings = new List<GameObject> ();
	public List<GameObject> deactivateTheseThings = new List<GameObject> ();

	void Start () {
		
	}

	void Update () {
		if (Boss == null) {
			foreach (GameObject thing in activateTheseThings) {
				thing.SetActive (true);
			}
			foreach (GameObject thing in deactivateTheseThings) {
				thing.SetActive (false);
			}
		}
	}
}
