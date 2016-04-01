using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Health : MonoBehaviour {

	public Slider slider;
	public float val = 0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(slider != null && slider.value > 0)
			slider.value = val--;
	}
}