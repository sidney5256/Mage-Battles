using UnityEngine;
using System.Collections;

public class IceSpell : MagicSpell {

	private readonly PlayerStats stats;
	public GameObject projectile;
	public float damage;
	public float manaCost;
	public float fireRate;
	public float nextFireTime;

	public IceSpell (){
		stats = PlayerStats.stats;
		damage = 5f;
		fireRate = .5f;
		manaCost = 6f;
		projectile = stats.iceProjectile;
		spellName = "Ice Blast";
		spellLevel = 1;
	}

	override public void UpdateSpell(){
		if (Input.GetKey (KeyCode.Mouse0) && stats.mana > manaCost && Time.time > nextFireTime) {
			CastSpell ();
		}
		if (Input.GetAxis ("Mouse ScrollWheel") != 0f || Input.GetKeyDown("2")){
			PlayerStats.stats.currSpell = PlayerStats.stats.fireSpell;
		}
	}

	override public void CastSpell(){
		GameObject.Instantiate (projectile, stats.projectileSpawn.position, stats.projectileSpawn.rotation);
		nextFireTime = Time.time + fireRate;
		stats.mana -= manaCost;
	}

}
