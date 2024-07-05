using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int fullHealth = 100;
	public int curHealth;
	private bool isDead;
    public TargetShot target;

	void Awake ()
	{
        TargetShot target = GameObject.Find("Target").GetComponent<TargetShot>();
		curHealth = fullHealth;
	}

	public void GetHit (int damageAmount)
	{
		if (isDead)
			return;

		curHealth -= damageAmount;
		if (curHealth <= 0)
			KillTarget ();
	}
	void KillTarget()
	{
        target.ts = true;
		Destroy(gameObject);
	}
}
