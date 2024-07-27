using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperAudio : MonoBehaviour
{
    ImageChange im;
    GameObject Player;
    public GameObject Wall;
    Transform playerTransform;
    public float dist;
    public bool isGreen;
    public AudioClip voiceLine;
    WeaponControl wc;
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
        Player = GameObject.Find("Player");
        playerTransform = Player.transform;
        float dist = Vector3.Distance (playerTransform.position, transform.position);
        if(Input.GetKey(KeyCode.E))
        {
            if(dist <= 3f)
            {
                if(isGreen)
                {
                    pickup();
                }
            }
        }
    }
    void pickup()
    {
        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
        im.GetComponent<ImageChange>().setWhite();
        Debug.Log("You have picked up a white paper!");
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
        wc.audio.PlayOneShot(voiceLine);
        Destroy(Wall);
        Destroy(gameObject);
    }
}