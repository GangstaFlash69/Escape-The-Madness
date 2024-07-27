using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Pickup : MonoBehaviour
{
    Shooting_Pistol shp;
    Shooting_Pistol shp2;
	public int AmmoBox = 30;
    public int HalfBox = 15;
    ImageChange im;
    WeaponControl wc;
    GameObject Player;
    Transform playerTransform;
    float dist;
    public bool isGreen;
    public AudioClip pickupclip;
    void Start()
    {
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>();
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
                    if(wc.GN17.activeInHierarchy)
                    {
                        GetAmmo1();
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
                        im.GetComponent<ImageChange>().setWhite();
                        Debug.Log("You have picked up " + (AmmoBox) + " Rounds !");
                    }
                    else if(wc.FHD.activeInHierarchy)
                    {
                        GetAmmo2();
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>();
                        im.GetComponent<ImageChange>().setWhite();
                        Debug.Log("You have picked up " + (AmmoBox) + " Rounds !");
                    }
                    else
                    {
                        Debug.Log("No Pistol found for this type of AMMO.");
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
                        im.GetComponent<ImageChange>().setRed();
                    }
                }
            }
        }
    }
    void GetAmmo1()
    {
        Shooting_Pistol shp = GameObject.Find("GN-17_Shooting").GetComponent<Shooting_Pistol> ();
        shp.AmmoCarry = shp.AmmoCarry + AmmoBox;
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
        wc.audio.PlayOneShot(pickupclip);
        Destroy(gameObject);
    }
    void GetAmmo2()
    {
        Shooting_Pistol shp2 = GameObject.Find("FHD_Shooting").GetComponent<Shooting_Pistol> ();
        shp2.AmmoCarry = shp2.AmmoCarry + AmmoBox;
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
        wc.audio.PlayOneShot(pickupclip);
        Destroy(gameObject);
    }
}