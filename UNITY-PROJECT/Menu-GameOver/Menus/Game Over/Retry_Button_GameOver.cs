using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Retry_Button_GameOver : MonoBehaviour {

	public void Retry()
	{
		SceneManager.LoadScene ("Catacombs");
	}
}
