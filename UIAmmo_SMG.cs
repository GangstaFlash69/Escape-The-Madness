using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIAmmo_SMG : MonoBehaviour
{
    public Shooting_SMG shs;
	public static int AmmoMag;
	public TMP_Text AmmoText;
	
	void Start ()
	{
		shs = FindObjectOfType<Shooting_SMG> ();
	}
	void Awake ()
	{
		AmmoText = GetComponent<TMP_Text> ();
		AmmoMag = shs.Ammo;
	}
	void LateUpdate ()
	{
		AmmoText.text = shs.AmmoLimit + " / " + shs.Ammo;
	}
}
