using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int fullHealth = 100;
	public int curHealth;
	private bool isDead;

	void Awake ()
	{
		curHealth = fullHealth;
	}

	public void GetHurt (int damageAmount)
	{
		if (isDead)
			return;

		curHealth -= damageAmount;
		if (curHealth <= 0)
			KillEnemy ();
	}
	void KillEnemy()
	{
		Destroy(gameObject);
	}
}