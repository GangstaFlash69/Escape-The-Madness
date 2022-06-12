using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int fullHealth = 100;
	public int CurHealth;
	public bool niggaIsDead = false;
	
	void Awake ()
	{
		CurHealth = fullHealth;
	}
	public void GetHurt(int damageAmount)
	{
		CurHealth -= damageAmount;
		if (CurHealth <= 0) {
			KillPlayer ();
		}
	}
	public void KillPlayer ()
	{
		niggaIsDead = true;
		GameMenu gm = GameObject.Find("GameMenu").GetComponent<GameMenu>();
		gm.DeathScreen.SetActive(true);
		gameObject.GetComponent<PlayerMovement>().enabled = false;
		MouseLook mc = GameObject.Find("MainCamera").GetComponent<MouseLook>();
		mc.GetComponent<MouseLook>().enabled = false;
	}
}