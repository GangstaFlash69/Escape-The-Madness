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
	WeaponControl wc;
	public AudioClip Byebye;
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
		rip = true;
		GameMenu gm = GameObject.Find("GameMenu").GetComponent<GameMenu>();
		gm.DeathScreen.SetActive(true);

		PlayerMovement pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
		pm.enabled = false;

		MouseLook ml = GameObject.Find("MainCamera").GetComponent<MouseLook>();
		ml.enabled = false;

		WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
		wc.audio.PlayOneShot(Byebye);
	}
}