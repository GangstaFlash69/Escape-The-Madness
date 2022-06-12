using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIHealth : MonoBehaviour
{
    public static int Health;
	public TMP_Text HealthText;
	public PlayerHealth  ph;

	void Start ()
	{
		ph = FindObjectOfType<PlayerHealth> ();
	}
	void Awake ()
	{
		HealthText = GetComponent<TMP_Text> ();
		Health = 100;
	}
	void LateUpdate ()
	{
		HealthText.text = "%" + ph.CurHealth;
	}
}
