using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject Icon_Active;
    public GameObject Icon_Inactive;
    Light flashLight;
    WeaponControl wc;
    void Start()
    {
        flashLight = GetComponent<Light>();
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(!flashLight.enabled)
            {
                flashLight.enabled = true;
                Icon_Active.SetActive(true);
                Icon_Inactive.SetActive(false);
                //wc.audio.PlayOneShot(click);
            }
            else
            {
                flashLight.enabled = false;
                Icon_Active.SetActive(false);
                Icon_Inactive.SetActive(true);
                //wc.audio.PlayOneShot(click2);
            }
        }
    }
}