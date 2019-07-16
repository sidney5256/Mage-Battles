using UnityEngine;
using System.Collections;

public class PlayerStatsDisplay : MonoBehaviour {

	private RectTransform rt;
	private Vector3 startingScale;
	public bool isHealth; //if not, then it's for mana

	void Start () {
		rt = GetComponent<RectTransform> ();
		startingScale = rt.localScale;
	}

	// Update is called once per frame
	void Update () {
		if (isHealth) {
			float healthPercent = PlayerStats.stats.health / PlayerStats.stats.healthMax * startingScale.x;
			rt.localScale = new Vector3 (healthPercent, startingScale.y, startingScale.z);
		} else {
			float manaPercent = PlayerStats.stats.mana / PlayerStats.stats.manaMax * startingScale.x;
			rt.localScale = new Vector3 (manaPercent, startingScale.y, startingScale.z);
		}
	}
}
