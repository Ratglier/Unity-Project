using UnityEngine;
using System.Collections;

public class Quit_Game_MainMenu_button : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void QuitGame()
	{
		// Save Game
		// Close Game
		Application.Quit();
	}
}
