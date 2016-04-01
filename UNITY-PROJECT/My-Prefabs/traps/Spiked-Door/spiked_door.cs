using UnityEngine;
using System.Collections;

public class spiked_door : MonoBehaviour {

	public GameObject door;
	private bool count;

	// Use this for initialization
	void Start () {
		count = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			if (count == true) {
				door.GetComponent<Animation> ().Play ("spikes");
			}
			count = !count;
		}
	}
}
