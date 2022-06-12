using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	public GameObject player;
	private PlayerHealth ph;

	public float timeToAttack = 0.5f;
	public int atkAmount = 10;
	private bool inRange = false;
	private float timer;
	
	void Awake ()
	{
		if (player == null)
			player = GameObject.FindGameObjectWithTag ("Player");
		ph = player.GetComponent<PlayerHealth> ();
	}

	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= timeToAttack && inRange == true) 
		{
			Attack(); 
		}
	}

	void Attack()
	{
		if (ph.CurHealth > 0)
			ph.GetHurt (atkAmount);
		timer = 0f;
	}

        void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}
