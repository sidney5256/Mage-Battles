using UnityEngine;
using System.Collections;

public class PaladinAI : MonoBehaviour {

	public GameObject player;
	public GameObject bolt;
	public Transform boltSpawn;
	private EnemyStats stats;
	public float nextStateTime; //in-game time to switch to next state

	public AudioClip crash;
	public AudioClip zap;
	public AudioClip charge;

	[HideInInspector]public AudioSource source;
	[HideInInspector] public UnityEngine.AI.NavMeshAgent nav;
	[HideInInspector] public Animator anim;
	[HideInInspector] public PaladinMeleeState meleeState;
	[HideInInspector] public PaladinRangedState rangedState;
	[HideInInspector] public PaladinPreRangedState preRangedState;
	[HideInInspector] public IPaladinStates currentState;

	void Start () {
		nextStateTime = Time.time + 20f;
		meleeState = new PaladinMeleeState (this);
		rangedState = new PaladinRangedState (this);
		preRangedState = new PaladinPreRangedState (this);
		currentState = meleeState;

		anim = GetComponent<Animator> ();
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		stats = GetComponent<EnemyStats> ();
		source = GetComponent<AudioSource> ();
	}

	void Update () {
		if (player == null) {
			return;
		}
		currentState.UpdateState ();
	}
	public IEnumerator MeleeAttack(){
		anim.Play ("PaladinMelee", -1, 0f);
		source.clip = crash;
		source.Play ();
		yield return new WaitForSeconds (.25f);
		PlayerStats.stats.TakeDamage (15f);
	}
	public IEnumerator RangedAttack(){
		anim.Play ("PaladinRanged", -1, 0f);
		yield return new WaitForSeconds (.2f);
		boltSpawn.LookAt (new Vector3(player.transform.position.x, player.transform.position.y + .1f, player.transform.position.z));
		Instantiate (bolt, boltSpawn.position, boltSpawn.rotation);
		source.clip = zap;
		source.Play ();
	}

	//can't do StartCoroutine outside of a monobehavior, so use this instead.
	public void RangedAttackPre(){
		StartCoroutine (RangedAttack ());
	}
	public void MeleeAttackPre(){
		StartCoroutine (MeleeAttack ());
	}
}
