using UnityEngine;
using System.Collections;

public class hidden_wall : MonoBehaviour {

	public GameObject door;
	public int count = 0;

	void	Update(){
		if (!door.GetComponent<Animation>().isPlaying ) {
			if (count == 1) {
				door.GetComponent<Animation> ().Play ("slidedown-door");
				count = 0;
			} else if (count == 2) {
				door.GetComponent<Animation> ().Play ("slideup-door");
				count = 0;
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player")
			count = 1;
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player")
			count = 2;
	}
}
