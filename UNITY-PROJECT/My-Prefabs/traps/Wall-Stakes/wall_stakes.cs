using UnityEngine;
using System.Collections;

public class wall_stakes : MonoBehaviour {

	public GameObject right_spikes;
	public GameObject left_spikes;

	private bool trigger = false;

	// Update is called once per frame
	void Update () {
		if (trigger) {
			right_spikes.GetComponent<Animation> ().Play ("stake1b");
			left_spikes.GetComponent<Animation> ().Play ("stake1a");
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
