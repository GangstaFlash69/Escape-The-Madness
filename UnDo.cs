﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnDo : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }
}
