using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform player;
    public UnityEngine.AI.NavMeshAgent agent;
    public PlayerHealth ph;
    public AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        PlayerHealth ph = GameObject.Find("PlayerModel").GetComponent<PlayerHealth>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void OnBecameInvisible()
    {
        audio.Play();
        transform.LookAt(player);
        Debug.Log("He ain't looking...");
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;
        agent.SetDestination(player.position);
    }
     void OnBecameVisible()
     {
        audio.Stop();
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
        Debug.Log("Oops...");
     }
     void OnTriggerEnter()
     {
        PlayerHealth ph = GameObject.Find("PlayerModel").GetComponent<PlayerHealth>();
        ph.KillPlayer();
     }
}