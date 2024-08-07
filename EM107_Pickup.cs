﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM107_Pickup : MonoBehaviour
{
    WeaponControl wc;
    ImageChange im;
    GameObject Player;
    Transform playerTransform;
    public float dist;
    public bool isGreen;
    public AudioClip pickupclip;
    public AudioSource audio;
    public GameObject gunModel;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>();
        im.GetComponent<ImageChange>().setGreen();
        isGreen = true;
    }
    void OnMouseExit()
    {
        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>();
        im.GetComponent<ImageChange>().setWhite();
        isGreen = false;
    }
    void Update()
    {  
        GameObject Player = GameObject.Find("Player");
        playerTransform = Player.transform;
        float dist = Vector3.Distance (playerTransform.position, transform.position);
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(dist <= 3f)
            {
                if(isGreen)
                {
                    WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
                    if(wc.CAT9.activeInHierarchy)
                    {
                        Debug.Log("You cannot carry more than 1 Rifle");
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
                        im.GetComponent<ImageChange>().setRed();
                    }
                    else if(wc.hasRifle == true)
                    {
                        Debug.Log("You cannot carry more than 1 Rifle");
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
                        im.GetComponent<ImageChange>().setRed();
                    }
                    else
                    {
                        pickup();
                    }
                }
            }
        }
    }
    void pickup()
    {
        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
        im.GetComponent<ImageChange>().setWhite();
        isGreen = false;
        Debug.Log("You have picked up a EM-107 Rifle");
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
        wc.EM107.SetActive (true);
        wc.hasRifle = true;
        GetComponent<AudioSource>().PlayOneShot(pickupclip);
        gunModel.SetActive (false);
        Destroy(gameObject, 2f);
    }
}
