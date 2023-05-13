using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIAmmo_Rifle : MonoBehaviour
{
    public Shooting_Rifle shr;
	public static int AmmoMag;
	public TMP_Text AmmoText;
	
	void Start ()
	{
		shr = FindObjectOfType<Shooting_Rifle> ();
	}
	void Awake ()
	{
		AmmoText = GetComponent<TMP_Text> ();
		AmmoMag = shr.Ammo;
	}
	void LateUpdate ()
	{
		AmmoText.text = shr.AmmoCarry + " / " + shr.Ammo;
	}
}
