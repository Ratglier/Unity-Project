using UnityEngine;
using System.Collections;

public class cam_view : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.Z))
		{     
			transform.Rotate (1f*Time.deltaTime*100,0f, 0f);
		}	
		if (Input.GetKey (KeyCode.X))
		{     
			transform.Rotate (1f*Time.deltaTime*-100,0f, 0f);
		}	
	}
}
