using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player_Ressources : MonoBehaviour {
	public GameObject player;
	public GameObject weapon;
	private PlayerInventory playerscript;
	
	private GameObject equipedWeapon;

	// Use this for initialization
	void Start () {
		playerscript = player.GetComponent<PlayerInventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerscript.UpdateHPBar ();
		playerscript.UpdateManaBar ();

	}
		
	public bool isPlayerAlive ()
	{
		if (getPlayerHealth () <= 0)
			return (false);
		else
			return (true);
	}

	public void playerIsDead()
	{
		GetComponent<Animation> ().CrossFade ("Dead");
	}

	public void changeWeapon (GameObject newWeapon)
	{
		equipedWeapon = newWeapon;
	}

	public void receiveDamage(float dommage)
	{
		if ((playerscript.currentHealth - dommage) <= 0) {
			playerscript.currentHealth = 0;
		}
		else
			playerscript.currentHealth -= dommage;
	}

	public void looseStamina(float value)
	{
		playerscript.currentMana -= value;
	}

	public float getPlayerHealth()
	{
		return (playerscript.currentHealth);
	}

	public float getPlayerStamina()
	{
		return(playerscript.currentMana);
	}
}