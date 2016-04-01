using UnityEngine;
using System.Collections;

public class vertical_booby_trap_damages : MonoBehaviour {

	public GameObject player_parent;
	public GameObject player;
	private Player_Ressources playerscript;

	private float alpha;
	private float beta;
	private float xaxis;
	private float zaxis;
	private Vector3 pos;

	void Start () {
		playerscript = player.GetComponent<Player_Ressources> ();
		pos = player_parent.transform.position;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			if (playerscript.getPlayerHealth() > 7)
			{
				playerscript.receiveDamage (7f);
			}
			else
			{
				playerscript.receiveDamage(playerscript.getPlayerHealth());
			}
			alpha = transform.rotation.eulerAngles.y;
			beta = alpha * (Mathf.PI / 180);
			xaxis = Mathf.Cos (beta);
			zaxis = Mathf.Sin (beta);
			pos = player_parent.transform.position;
			pos.x -= xaxis * 0.5f;
			pos.z -= zaxis * 0.5f;
			player_parent.transform.position = pos;
		}
	}
}
