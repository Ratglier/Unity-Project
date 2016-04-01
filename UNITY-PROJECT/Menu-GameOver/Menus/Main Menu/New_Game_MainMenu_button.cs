using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class New_Game_MainMenu_button : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		NewGame();
	}
	
	public void NewGame()
	{
		SceneManager.LoadScene ("Catacombs");
	}
}
