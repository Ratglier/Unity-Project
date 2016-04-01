using UnityEngine;
using System.Collections;

public class rotating_saw : MonoBehaviour {

	public GameObject blade_rotation;
	public GameObject blade_axis;

	private bool trigger = false;

	// Update is called once per frame
	void Update () {
		if (trigger) {
			blade_rotation.GetComponent<Animation> ().Play ("blade1");
			blade_axis.GetComponent<Animation> ().Play ("blade_col1");
		}
		else if (blade_axis.GetComponent<Animation> ().isPlaying)
			blade_rotation.GetComponent<Animation> ().Play ("blade1");
			
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