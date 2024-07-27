using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSensor : MonoBehaviour
{
    public GameObject Icon_Active;
    public GameObject Icon_Inactive;
    public GameObject Screen;
    public AudioClip click;
    public WeaponControl wc;

    void Start ()
    {
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Screen.activeInHierarchy)
            {
                Screen.SetActive(false);
                Icon_Active.SetActive(false);
                Icon_Inactive.SetActive(true);
                wc.audio.PlayOneShot(click);
            }
            else
            {
                Screen.SetActive(true);
                Icon_Active.SetActive(true);
                Icon_Inactive.SetActive(false);
                wc.audio.PlayOneShot(click);
            }
        }
    }
}
