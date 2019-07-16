using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

	public int waitTime;

	void Start () {
		Destroy (gameObject, waitTime);
	}
}
