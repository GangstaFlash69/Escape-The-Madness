using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Spawn : MonoBehaviour
{
    public GameObject obj;

    void OnTriggerEnter( Collider Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            obj.SetActive(false);
            Destroy(gameObject);
        }
    }
}