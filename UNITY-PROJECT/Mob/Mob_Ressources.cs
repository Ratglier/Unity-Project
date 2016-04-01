using UnityEngine;
using System.Collections;

public class Mob_Ressources : MonoBehaviour {
	private float maxHealth;
	private float currentHealth;

	// Use this for initialization
	void Start () {
		maxHealth = 70;
		currentHealth = 70;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void receiveDommage(float dommage)
	{
		currentHealth -= dommage;
	}

	public float getHealth()
	{
		return (currentHealth);
	}
}
