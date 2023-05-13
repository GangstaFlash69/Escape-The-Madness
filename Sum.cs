using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sum : MonoBehaviour
{
    int zeby,tezy,kosy,bezy,rasy,baty,edey;

    void  Start()
    {
        zeby = 1;
        tezy = 2;

        kosy = zeby + tezy;
        bezy = tezy - zeby;
        rasy = zeby * tezy;
        baty = zeby % tezy;
        edey = zeby / tezy;

        Debug.Log("Kosy = " + (kosy));
        Debug.Log("Bezy = " + (bezy));
        Debug.Log("Rasy = " + (rasy));
        Debug.Log("Baty = " + (baty));
        Debug.Log("Edey = " + (edey));
    }
}