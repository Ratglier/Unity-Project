﻿using UnityEngine;
using System.Collections;

public class booby_trap : MonoBehaviour {

	public GameObject trunk_rotation;
	public GameObject trunk_axis;

	private bool trigger = false;

	// Update is called once per frame
	void Update () {
		if (trigger) {
			trunk_rotation.GetComponent<Animation> ().Play ("trunk");
			trunk_axis.GetComponent<Animation> ().Play ("arm");
		}
		else if (trunk_axis.GetComponent<Animation> ().isPlaying)
			trunk_rotation.GetComponent<Animation> ().Play ("trunk");

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
