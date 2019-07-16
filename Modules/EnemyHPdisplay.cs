using UnityEngine;
using System.Collections;

public class EnemyHPdisplay : MonoBehaviour {

	public EnemyStats stats;
	private RectTransform rt;
	private Vector3 startingScale;

	void Start () {
		rt = GetComponent<RectTransform> ();
		startingScale = rt.localScale;
	}

	// Update is called once per frame
	void Update () {
		float healthPercent = stats.health / stats.maxHealth * startingScale.x;
		rt.localScale = new Vector3 (healthPercent, startingScale.y, startingScale.z);
	}
}
