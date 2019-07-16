using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeDispTextTrig : MonoBehaviour {

	public string newText;
	public Text displayText;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Player")){
			displayText.text = newText;
		}
	}
	void OnTriggerExit(){
		displayText.text = "";
	}
}
