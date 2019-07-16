using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStats : MonoBehaviour {

	public static PlayerStats stats;

	public Transform projectileSpawn;
	public GameObject iceProjectile;
	public GameObject flameProjectile;
	public GameObject flameHitBox;
	public FirstPersonController controller;
	public Text dispText;

	public float health = 100f;
	public float healthMax = 100f;
	public float mana = 100f;
	public float manaMax = 100f;
	public float manaRegen = 5f;
	[HideInInspector] public bool isSpendingMana;
	[HideInInspector] public bool isGameOver;

	private AudioSource source;

	[HideInInspector] public IceSpell iceSpell;	//each spell is its own class, and is active when it is the "currSpell"
	[HideInInspector] public FireSpell fireSpell; //every spell inherits from "MagicSpell"
	[HideInInspector] public MagicSpell currSpell; //use polymorphism to switch spells

	void Awake(){
		stats = this;
		iceSpell = new IceSpell ();
		fireSpell = new FireSpell ();
	}

	void Start () {
		source = GetComponent<AudioSource> ();
		currSpell = iceSpell;
	}

	void Update () {
		if (isGameOver) {
			return;
		}

		if (mana < manaMax && !fireSpell.isFlameOn && !isSpendingMana) {
			mana += manaRegen * Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			mana -= 1f;
		}

		if (Input.GetKey (KeyCode.LeftShift)) {
			mana -= 3f * Time.deltaTime;
			isSpendingMana = true;
		} else {
			isSpendingMana = false;
		}

		currSpell.UpdateSpell (); //allows current spell to be casted (see each spell class for details)

		mana = Mathf.Clamp(mana, 0f, manaMax); //keeps mana and health within legal values
		health = Mathf.Clamp (health, 0f, healthMax);

		if (health <= 0f) {
			StartCoroutine(GameOver ());
		}
	}

	public void TakeDamage(float dmg){
		source.pitch = Random.Range (.8f, 1f);
		source.Play ();
		health -= dmg;
	}
	public IEnumerator GameOver(){

		isGameOver = true;

		controller.enabled = false;
		Destroy (controller.gameObject);
		transform.SetParent (null);
		transform.DetachChildren ();

		GetComponent<BoxCollider> ().isTrigger = false;
		GetComponent<Rigidbody> ().isKinematic = false;
		GetComponent<Rigidbody> ().useGravity = true;

		//for some reason all this stuff gets deactivated, so I have to activate them again. Don't know why
		GetComponent<Camera> ().enabled = true;
		GetComponent<AudioListener> ().enabled = true;
		GetComponent<AudioSource> ().enabled = true;

		transform.Rotate (new Vector3 (0f, 0f, 60f));
		AudioSource.PlayClipAtPoint (source.clip, transform.position);
		dispText.fontSize = 50;
		dispText.text = "GAME OVER. RESTARTING IN 10 SECONDS.";

		yield return new WaitForSeconds (10f);
		SceneManager.LoadScene ("Scene");
	}
}
