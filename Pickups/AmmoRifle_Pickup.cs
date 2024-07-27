using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRifle_Pickup : MonoBehaviour
{
    Shooting_Rifle shr;
    Shooting_Rifle shr2;
	public int AmmoBox = 30;
    public int HalfBox = 15;
    ImageChange im;
    WeaponControl wc;
    GameObject Player;
    Transform playerTransform;
    float dist;
    public bool isGreen;
    public AudioClip pickupclip;
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
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
                        im.GetComponent<ImageChange>().setWhite();
                        Debug.Log("You have picked up " + (AmmoBox) + " Rounds !");
                        GetAmmo2();
                    }
                    else if(wc.EM107.activeInHierarchy)
                    {
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>();
                        im.GetComponent<ImageChange>().setWhite();
                        Debug.Log("You have picked up " + (AmmoBox) + " Rounds !");
                        GetAmmo1();
                    }
                    else
                    {
                        Debug.Log("No Rifle found for this type of AMMO.");
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
                        im.GetComponent<ImageChange>().setRed();
                    }
                }
            }
        }
    }

    void GetAmmo1()
    {
        Shooting_Rifle shr = GameObject.Find("EM-107_Shooting").GetComponent<Shooting_Rifle> ();
        shr.AmmoCarry = shr.AmmoCarry + AmmoBox;
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
        wc.audio.PlayOneShot(pickupclip);
        Destroy(gameObject);
    }
    void GetAmmo2()
    {
        Shooting_Rifle shr2 = GameObject.Find("CAT-9_Shooting").GetComponent<Shooting_Rifle> ();
        shr2.AmmoCarry = shr2.AmmoCarry + AmmoBox;
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
        wc.audio.PlayOneShot(pickupclip);
        Destroy(gameObject);
    }
}