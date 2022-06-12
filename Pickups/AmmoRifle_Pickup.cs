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
        if(Input.GetKey(KeyCode.E))
        {
            if(dist <= 3f)
            {
                if(isGreen)
                {
                    WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
                    if(wc.GG10.activeInHierarchy)
                    {
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
                        im.GetComponent<ImageChange>().setWhite();
                        Debug.Log("You have picked up " + (AmmoBox) + " Rounds !");
                        GetAmmo2();
                        Destroy(gameObject);
                    }
                    else if(wc.CT22.activeInHierarchy)
                    {
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>();
                        im.GetComponent<ImageChange>().setWhite();
                        Debug.Log("You have picked up " + (AmmoBox) + " Rounds !");
                        GetAmmo1();
                        Destroy(gameObject);
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
        Shooting_Rifle shr = GameObject.Find("CT-22").GetComponent<Shooting_Rifle> ();
        shr.AmmoLimit = shr.AmmoLimit + AmmoBox;
    }
    void GetAmmo2()
    {
        Shooting_Rifle shr2 = GameObject.Find("GG-10").GetComponent<Shooting_Rifle> ();
        shr2.AmmoLimit = shr2.AmmoLimit + AmmoBox;
    }
}
