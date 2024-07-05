using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShot : MonoBehaviour
{
    public bool ts = false;
	void Update()
	{
        if(ts == true)
        {
            TargetFall();
        }
	}
    void TargetFall()
    {
        ts = false;
        gameObject.AddComponent<Rigidbody>();
        TargetsManager tm = GameObject.Find("TargetsManager").GetComponent<TargetsManager>();
        tm.total ++;
    }
}