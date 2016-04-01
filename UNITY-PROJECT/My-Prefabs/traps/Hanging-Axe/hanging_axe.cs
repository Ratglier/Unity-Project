using UnityEngine;
using System.Collections;

public class hanging_axe : MonoBehaviour {

	public GameObject axe;

	private bool trigger = false;

	// Use this for initialization
//	void Start () {
//
//	}
	
	// Update is called once per frame
	void Update () {
		if (trigger) {
			axe.GetComponent<Animation> ().Play ("blade2");
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