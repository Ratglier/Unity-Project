using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	private int state;
	public void Play_door_animation () 
	{
		if (Input.GetMouseButton (0)) 
		{
			if (state == 0) {
				GetComponent<Animation>().Play ("DOOR-OPEN");
				state = 1;
			}
			if (state == 1) {
				GetComponent<Animation>().Play ("DOOR-OPEN");
				state = 0;
			}
		}		
	}
}
