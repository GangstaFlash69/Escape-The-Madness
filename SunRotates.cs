using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotates : MonoBehaviour
{
    private float speed = 0.0005f;
    void Update()
    {
		transform.Rotate (Vector3.up, speed);
    }
}