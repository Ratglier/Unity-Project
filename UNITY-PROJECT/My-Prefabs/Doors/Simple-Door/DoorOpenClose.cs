using UnityEngine;
using System.Collections;


public class DoorOpenClose : MonoBehaviour {

	public GameObject door;
	private bool doorOpen = false;
	private bool trigger = false;

	void	Update(){
		if (trigger == true) {
			if (Input.GetKeyDown ("e")) {
				if (!doorOpen) {
					if (!door.GetComponent<Animation>().isPlaying)
						door.GetComponent<Animation>().Play ("DoorOpen");
				} else {
					if (!door.GetComponent<Animation>().isPlaying)
						door.GetComponent<Animation>().Play ("DoorClose");
				}
				doorOpen = !doorOpen;
			}
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player")
			trigger = true;
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Player")
			trigger = false;
	}
}