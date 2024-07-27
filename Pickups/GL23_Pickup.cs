using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GL23_Pickup : MonoBehaviour
{
    WeaponControl wc;
    ImageChange im;
    GameObject Player;
    Transform playerTransform;
    public float dist;
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
                    if(wc.EM107.activeInHierarchy)
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
        Debug.Log("You have picked up a CAT-9 Rifle");
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
        wc.CAT9.SetActive (true);
        wc.hasRifle = true;
        wc.audio.PlayOneShot(pickupclip);
        Destroy(gameObject);
    }
}