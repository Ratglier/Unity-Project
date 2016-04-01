using UnityEngine;
using System.Collections;


public class DoorOpenClose : MonoBehaviour {

	private bool doorOpen = false;
	private float animationFinished = 0;
	private Animation anim;


	public void OnMouseUp()
	{
		Debug.Log ("Ive been clicked");

		if(Time.time > animationFinished)
		{
			if(doorOpen)
			{
				anim = GetComponent<Animation>();
				anim.Play("DoorClose");
			}
			else
			{
				anim = GetComponent<Animation>();
				anim.Play("DoorOpen");
			}

			animationFinished = Time.time + 1;
			doorOpen = !doorOpen;
		}
	}
}