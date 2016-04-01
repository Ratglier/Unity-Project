using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour 
{
	public float look_sens = 7f;
	public float x_rotation;
	public float y_rotation;
	public float Current_x;
	public float Current_y;
	public float XrotationV;
	public bool block;
	public float YrotationV;
	public float look_smooth = 01f;
	// Use this for initialization
	void Start () {
		block = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.I)) {
			block = !block;
		}
		if (block == false) {
			x_rotation -= Input.GetAxis ("Mouse Y") * look_sens;
			y_rotation += Input.GetAxis ("Mouse X") * look_sens;
			//Quaternion is used to make rotations kind of
			transform.rotation = Quaternion.Euler (x_rotation, y_rotation, 0f); 
		}
	}
}
/* bidirectional
public class Follow : MonoBehaviour 
{
	public float look_sens = 4f;
	public float x_rotation;
	public float y_rotation;
	public float Current_x;
	public float Current_y;
	public float XrotationV;
	public float YrotationV;
	public float look_smooth = 01f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		x_rotation -= Input.GetAxis ("Mouse Y") * look_sens;
		y_rotation += Input.GetAxis ("Mouse X") * look_sens;
		//Quaternion is used to make rotations kind of
		transform.rotation = Quaternion.Euler(x_rotation, y_rotation, 0f); 
	}
}
*/