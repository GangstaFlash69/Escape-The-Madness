using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
	public GameObject enemy;
	public int enemiesNO = 1;
    public Transform trans;
	
	void OnTriggerEnter (Collider Other)
	{
		if (Other.gameObject.tag == "Player")
			for(int i=1; i<= enemiesNO;  i++)
		{
			Instantiate (enemy,trans.position,trans.rotation);
		}
		Destroy (gameObject);
	}
}
