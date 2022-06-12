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
                    if(wc.FT5.activeInHierarchy)
                    {
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
                        im.GetComponent<ImageChange>().setWhite();
                        Debug.Log("You have picked up " + (AmmoBox) + " Rounds !");
                        GetAmmo1();
                        Destroy(gameObject);
                    }
                    else if(wc.FHD.activeInHierarchy)
                    {
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>();
                        im.GetComponent<ImageChange>().setWhite();
                        Debug.Log("You have picked up " + (AmmoBox) + " Rounds !");
                        GetAmmo2();
                        Destroy(gameObject);
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
        Shooting_Pistol shp = GameObject.Find("FT-5").GetComponent<Shooting_Pistol> ();
        shp.AmmoLimit = shp.AmmoLimit + AmmoBox;
    }
    void GetAmmo2()
    {
        Shooting_Pistol shp2 = GameObject.Find("FHD").GetComponent<Shooting_Pistol> ();
        shp2.AmmoLimit = shp2.AmmoLimit + AmmoBox;
    }
}
