﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform player;
    public UnityEngine.AI.NavMeshAgent agent;
    public PlayerHealth ph;
    void Start()
    {
        PlayerHealth ph = GameObject.Find("PlayerModel").GetComponent<PlayerHealth>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void OnBecameInvisible()
    {
        transform.LookAt(player);
        Debug.Log("Nigga ain't looking...");
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;
        agent.SetDestination(player.position);
    }
     void OnBecameVisible()
     {
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
        Debug.Log("Stopping...");
     }
     void OnTriggerEnter()
     {
        PlayerHealth ph = GameObject.Find("PlayerModel").GetComponent<PlayerHealth>();
        ph.KillPlayer();
     }
}