using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnEnter : MonoBehaviour {

	public string nameOfScene;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			SceneManager.LoadScene (nameOfScene);
		}
	}
}
