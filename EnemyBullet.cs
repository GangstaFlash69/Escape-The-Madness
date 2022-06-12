using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAttack;
    void Start()
    {
        damageAttack = 25;
        Destroy(gameObject, 2f);
    }
    void OnCollisonEnter(Collider oollider)
    {   
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        PlayerHealth ph = GameObject.Find("Player").GetComponent<PlayerHealth>();
        ph.GetHurt(damageAttack);
    }
}
