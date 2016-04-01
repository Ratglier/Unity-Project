using UnityEngine;
using System.Collections;

public class lateral_sliding_doors : MonoBehaviour {

	public GameObject left_door;
	public GameObject right_door;
	public Animation anim_left;
	public Animation anim_right;
	public int count = 0;	

	void	Start(){
		anim_left = left_door.GetComponent<Animation> ();
		anim_right = right_door.GetComponent<Animation> ();
	}

	void	Update(){
		if (!anim_left.isPlaying || !anim_right.isPlaying) {
			if (count == 1) {
				left_door.GetComponent<Animation> ().Play ("left-sliding-door");
				right_door.GetComponent<Animation> ().Play ("right-sliding-door");
				count = 0;
			} else if (count == 2) {
				left_door.GetComponent<Animation> ().Play ("left-closing-door");
				right_door.GetComponent<Animation> ().Play ("right-closing-door");
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