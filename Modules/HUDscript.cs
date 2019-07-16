using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDscript: MonoBehaviour {

	private Text HUD;
	private string currWep;

	void Start () {
		HUD = GetComponent<Text> ();
	}
		
	void Update () {
		currWep = PlayerStats.stats.currSpell.spellName;
		HUD.text = "\tHealth: " + Mathf.Round(PlayerStats.stats.health) + " / " + Mathf.Round(PlayerStats.stats.healthMax) +
			"\n\tMana: " + Mathf.Round(PlayerStats.stats.mana) + " / " + Mathf.Round(PlayerStats.stats.manaMax) +
			"\nCurrent Spell: " + currWep;
	}
}
