using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MusicTriggeringScript : MonoBehaviour {

	public AudioMixerSnapshot noMusic;
	public AudioMixerSnapshot music1;
	public AudioMixerSnapshot bossmusic;
	private AudioSource[] sources;

	void Start () {
		sources = GetComponents<AudioSource> ();
		noMusic.TransitionTo (1f);
	}
	
	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Music1")){
			sources [0].Stop ();
			sources [0].Play ();
			music1.TransitionTo(3f);
		}
		if (other.CompareTag ("BossMusic")) {
			sources [1].Stop ();
			sources [1].Play ();
			bossmusic.TransitionTo (5f);
		}
	}
}
