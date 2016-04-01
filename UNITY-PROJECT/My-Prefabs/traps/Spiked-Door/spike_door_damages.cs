using UnityEngine;
using System.Collections;

public class spike_door_damages : MonoBehaviour {

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
			if (playerscript.getPlayerHealth() > 10)
			{
				playerscript.receiveDamage (10f);
			}
			else
			{
				Debug.Log ("death");
				playerscript.receiveDamage(playerscript.getPlayerHealth());
			}
			alpha = transform.rotation.eulerAngles.y;
			beta = alpha * (Mathf.PI / 180);
			xaxis = Mathf.Cos (beta);
			zaxis = Mathf.Sin (beta);
			pos = player_parent.transform.position;
			pos.x -= xaxis * 0.7f;
			pos.z -= zaxis * 0.7f;
			player_parent.transform.position = pos;
		}
	}
}