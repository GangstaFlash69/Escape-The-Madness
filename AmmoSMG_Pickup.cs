using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSMG_Pickup : MonoBehaviour
{
    public Shooting_SMG shs;
    public Shooting_SMG shs2;
	public int AmmoBox = 30;
    ImageChange im;
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
                    if(wc.GT7s.activeInHierarchy)
                    {
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
                        im.GetComponent<ImageChange>().setWhite();
                        Debug.Log("You have picked up " + (AmmoBox) + " Rounds !");
                        GetAmmo1();
                        Destroy(gameObject);
                    }
                    else if(wc.GT8.activeInHierarchy)
                    {
                        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>();
                        im.GetComponent<ImageChange>().setWhite();
                        Debug.Log("You have picked up " + (AmmoBox) + " Rounds !");
                        GetAmmo2();
                        Destroy(gameObject);
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
        Shooting_SMG shs = GameObject.Find("GT-7s").GetComponent<Shooting_SMG> ();
        shs.AmmoLimit = shs.AmmoLimit + AmmoBox;
    }
    void GetAmmo2()
    {
        Shooting_SMG shs2 = GameObject.Find("GT-8").GetComponent<Shooting_SMG> ();
        shs2.AmmoLimit = shs2.AmmoLimit + AmmoBox;
    }
}
