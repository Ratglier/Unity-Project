using UnityEngine;
using System.Collections;

public class inputhandler : MonoBehaviour 
{	
	void Update () 
	{
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit rayCastHit;
			if (Physics.Raycast (ray.origin, ray.direction, out rayCastHit, Mathf.Infinity))
			{
				Door door = rayCastHit.transform.GetComponent<Door> ();
				if (door)
					door.Play_door_animation ();

			}
		}	
	}
}
