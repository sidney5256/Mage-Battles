using UnityEngine;
using System.Collections;

public class EnemyStatesAI : MonoBehaviour {

	public float searchingTurnSpeed = 20f;
	public float searchingDuration = 3f;
	public SphereCollider alertRadius;
	public Transform[] wayPoints;
	public AudioClip seenSound;
	public AudioClip alertSound;
	public TextMesh symbol;
	public GameObject player;
	public bool isArcher;

	[HideInInspector] public Transform engageTarget;
	[HideInInspector] public IEnemyStates currentState;
	[HideInInspector] public EngageState engageState;
	[HideInInspector] public AlertState alertState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;

	void Awake(){
		engageState = new EngageState (this);
		alertState = new AlertState (this);
		patrolState = new PatrolState (this);
		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		currentState = patrolState;

	}
	void Start(){

	}
	void Update(){
		if (player == null) {
			return;
		}
		currentState.UpdateState ();
	}

}
