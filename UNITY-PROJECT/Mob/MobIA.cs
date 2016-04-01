using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobIA : MonoBehaviour {
	public NavMeshAgent agent;
	public GameObject player;
	public float Damage;
	public GameObject mob;

	private GameObject player_2;
	private Player_Ressources playerscript;
	private Mob_Ressources mobscript;
	private bool punchable;
	private bool aggroed;
	private bool died;
	private Vector3 initPos;
	private Vector3 playerPos;

	void Start () {
		punchable = false;
		aggroed = false;
		died = false;
		player_2 = GameObject.FindGameObjectWithTag("Player");
		initPos = agent.transform.position;
		agent = GetComponent<NavMeshAgent>();
		playerscript = player.GetComponent<Player_Ressources> ();
		mobscript = mob.GetComponent<Mob_Ressources> ();
	}

	void Update ()
	{
		if (mobscript.getHealth () > 0) {
			playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
			if ((agent.transform.position.x == initPos.x) && (agent.transform.position.z == initPos.z)) {
				if (aggroed == true) {
					if (punchable == true) {
						agent.transform.LookAt (playerPos);
						if (!agent.GetComponent<Animation> ().IsPlaying ("attack2")) {
							agent.GetComponent<Animation> ()["attack2"].speed = 0.75f;
							agent.GetComponent<Animation> ().CrossFade ("attack2");
							attackPlayer (Damage);
						}
					} else {
						agent.transform.LookAt (playerPos);
						agent.GetComponent<Animation> ()["walk"].speed = 0.60f;
						agent.GetComponent<Animation> ().CrossFade ("walk");
						agent.SetDestination (playerPos);
					}
				} else {
					agent.GetComponent<Animation> ().CrossFade ("idle");	
				}
			} else {
				if (aggroed == true) {
					if (punchable == true) {
						agent.transform.LookAt (playerPos);
						if (!agent.GetComponent<Animation> ().IsPlaying ("attack2")) {
							agent.GetComponent<Animation> ()["attack2"].speed = 0.75f;
							agent.GetComponent<Animation> ().CrossFade ("attack2");
							attackPlayer (Damage);
						}
					} else {
						agent.transform.LookAt (playerPos);
						agent.GetComponent<Animation> ()["walk"].speed = 0.60f;
						agent.GetComponent<Animation> ().CrossFade ("walk");
						agent.SetDestination (playerPos);
					}
				} else {
					agent.transform.LookAt (initPos);
					agent.GetComponent<Animation> ()["walk"].speed = 0.60f;
					agent.GetComponent<Animation> ().CrossFade ("walk");
					agent.SetDestination (initPos);
				}
			}
		} else {
			if (died == false) {
				agent.GetComponent<Animation> ().CrossFade ("die");
				died = true;
				Destroy (mob, 60);
			}
		}
	}

	public void attackPlayer(float dommage)
	{
		print ("OUCH !");
		if (playerscript.getPlayerHealth () > 0) {
			playerscript.receiveDamage (dommage);
			player_2.GetComponent<Animation> ().Play ("Cover_sword_hit");	
		}
	}

	public void OnTriggerEnter (Collider collider)
	{
		if (collider.GetComponent<Collider> ().tag == "Player") {
			aggroed = true;
		}
	}

	public void OnTriggerExit(Collider collider)
	{
		if (collider.GetComponent<Collider> ().tag == "Player") {
			aggroed = false;
		}
	}

	public void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Player") {
			punchable = true;
		} else
			punchable = false;
	}

	public void OnCollisionStay(Collision collision)
	{
		if (collision.collider.tag == "Player") {
			punchable = true;
		} else
			punchable = false;
	}

	public void OnCollisionExit(Collision collision)
	{
		if (collision.collider.name == "Player") {
			punchable = false;
		}
	}
}