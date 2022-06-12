using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject Icon_Active;
    public GameObject Icon_Inactive;
    Light flashLight;
    AudioSource audioClick;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            flashLight = GetComponent<Light>();
            audioClick = GetComponent<AudioSource>();
            if(!flashLight.enabled)
            {
                flashLight.enabled = true;
                Icon_Active.SetActive(true);
                Icon_Inactive.SetActive(false);
                audioClick.Play();
            }
            else
            {
                flashLight.enabled = false;
                Icon_Active.SetActive(false);
                Icon_Inactive.SetActive(true);
                audioClick.Play();
            }
        }
    }
}