using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform player;
    void OnBecameInvisible()
    {
        player = GameObject.Find("Player").transform;
        transform.LookAt(player);
    }

     void OnBecameVisible()
     {
        Debug.Log("Waiting...");
     }
}
