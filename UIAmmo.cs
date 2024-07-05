using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIAmmo : MonoBehaviour
{
    public Shooting_Pistol shp;
	public static int AmmoMag;
	public TMP_Text AmmoText;
	
	void Start ()
	{
		Shooting_Pistol shp = FindObjectOfType<Shooting_Pistol>();
	}
	void Awake ()
	{
		AmmoText = GetComponent<TMP_Text> ();
		AmmoMag = shp.Ammo;
	}
	void LateUpdate ()
	{
		AmmoText.text = shp.AmmoCarry + " / " + shp.Ammo;
	}
}
