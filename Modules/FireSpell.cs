using UnityEngine;
using System.Collections;

public class FireSpell : MagicSpell {

	private readonly PlayerStats stats;
	public GameObject projectile;
	public GameObject hitBox;
	public bool isFlameOn;
	public float damage;
	public float manaCost;

	public FireSpell (){
		stats = PlayerStats.stats;
		damage = 15f; // per second
		manaCost = 10f; //per second
		projectile = stats.flameProjectile;
		hitBox = stats.flameHitBox;
		spellName = "Flamethrower";
		spellLevel = 1;
	}

	override public void UpdateSpell(){
		if (Input.GetKeyDown (KeyCode.Mouse0) && stats.mana > 1f) {
			CastSpell ();
		} else if (Input.GetKeyUp (KeyCode.Mouse0)) {
			StopSpell ();
		}
		if (isFlameOn) {
			stats.mana -= manaCost * Time.deltaTime;
		}
		if (Input.GetAxis ("Mouse ScrollWheel") != 0f || Input.GetKeyDown("1")) {
			PlayerStats.stats.currSpell = PlayerStats.stats.iceSpell;
		}
		if (stats.mana < 0f) {
			StopSpell ();
		}
	}

	override public void CastSpell(){
		//turns ON flamethrower
		if (!isFlameOn) {
			projectile.GetComponent<ParticleSystem>().Play ();
			projectile.GetComponent<AudioSource> ().Play ();
			hitBox.GetComponent<FlameThrower> ().isOn = true;
			isFlameOn = true;
		}
	}
	public void StopSpell(){
		//turns OFF flamethrower
		if (isFlameOn) {
			projectile.GetComponent<ParticleSystem>().Stop ();
			projectile.GetComponent<AudioSource> ().Stop ();
			hitBox.GetComponent<FlameThrower> ().isOn = false;
			isFlameOn = false;
		}
	}

}
