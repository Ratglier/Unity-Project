using UnityEngine;
using System.Collections;


public class lever_activation : MonoBehaviour {

	private bool leverdown = false;
	private float animationFinished = 0;
	private Animation anim;
	private bool trigger = false;

	public GameObject door;

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player")
			trigger = true;
		}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Player")
			trigger = false;
	}

	public void OnMouseUp(){
		if (trigger == true)
		{
			if(Time.time > animationFinished)
			{
				anim = GetComponent<Animation>();
				if(!leverdown)
				{
					anim.Play("lever_down");
					door.GetComponent<Animation>().Play("slidedown-door");
				}
				else
				{
					anim.Play("lever_up");
					door.GetComponent<Animation>().Play("slideup-door");
				}
				animationFinished = Time.time + 1;
				leverdown = !leverdown;
			}
		}
	}
}