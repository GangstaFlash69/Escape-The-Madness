﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2f);
    }
    void OnCollisonEnter(Collider collider)
    {
        Destroy(gameObject);
    }
}
