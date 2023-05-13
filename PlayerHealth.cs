using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int fullHealth = 100;
	public int CurHealth;
	public bool rip = false;
	PlayerMovement pm;
	MouseLook ml;

	public AudioSource Byebye;


	
	void Awake ()
	{
		CurHealth = fullHealth;
		Byebye = GetComponent<AudioSource>();
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
		rip = true;
		GameMenu gm = GameObject.Find("GameMenu").GetComponent<GameMenu>();
		gm.DeathScreen.SetActive(true);

		PlayerMovement pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
		pm.enabled = false;

		MouseLook ml = GameObject.Find("MainCamera").GetComponent<MouseLook>();
		ml.enabled = false;

		Byebye.Play();
	}
}