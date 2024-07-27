using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSMG_Pickup : MonoBehaviour
{
    Shooting_SMG shs;
    Shooting_SMG shs2;
	public int AmmoBox = 30;
    WeaponControl wc;
    ImageChange im;
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
                    if(wc.SUP5.activeInHierarchy)
                    {
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
                        im.GetComponent<ImageChange>().setWhite();
                        Debug.Log("You have picked up " + (AmmoBox) + " Rounds !");
                        GetAmmo1();
                    }
                    else if(wc.SUP7.activeInHierarchy)
                    {
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>();
                        im.GetComponent<ImageChange>().setWhite();
                        Debug.Log("You have picked up " + (AmmoBox) + " Rounds !");
                        GetAmmo2();
                    }
                    else
                    {
                        Debug.Log("No SMG found for this type of AMMO.");
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
                        im.GetComponent<ImageChange>().setRed();
                    }
                }
            }
        }
    }

    void GetAmmo1()
    {
        Shooting_SMG shs = GameObject.Find("SUP5_Shooting").GetComponent<Shooting_SMG> ();
        shs.AmmoCarry = shs.AmmoCarry + AmmoBox;
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
        wc.audio.PlayOneShot(pickupclip);
        Destroy(gameObject);
    }
    void GetAmmo2()
    {
        Shooting_SMG shs2 = GameObject.Find("GT-8").GetComponent<Shooting_SMG> ();
        shs2.AmmoCarry = shs2.AmmoCarry + AmmoBox;
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
        wc.audio.PlayOneShot(pickupclip);
        Destroy(gameObject);
    }
}
