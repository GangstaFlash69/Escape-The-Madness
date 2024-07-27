using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCutter : MonoBehaviour
{
    public bool isCutting = false;
    public float coolDown;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(CutWire());
        }  
    }
    IEnumerator CutWire()
    {
        gameObject.GetComponent<Animator>().SetBool("cut", true);
        isCutting = true;
        yield return new WaitForSeconds(coolDown);
        gameObject.GetComponent<Animator>().SetBool("cut", false);
        isCutting = false;
    }
}
