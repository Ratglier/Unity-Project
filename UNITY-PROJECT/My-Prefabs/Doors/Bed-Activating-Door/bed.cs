using UnityEngine;
using System.Collections;

public class bed : MonoBehaviour {

	public GameObject left_door;
	public GameObject right_door;

//	private float animationFinished = 0;
	private bool trigger = false;

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player")
			trigger = true;
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Player")
			trigger = false;
	}

	void	Update(){
		if (trigger == true) {
			if (Input.GetKeyDown ("e")) {
				left_door.GetComponent<Animation> ().Play ("DoorOpen");
				right_door.GetComponent<Animation> ().Play ("Door2Open");
			}
		}
	}
}