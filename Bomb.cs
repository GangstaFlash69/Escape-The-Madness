using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public ImageChange im;
    GameObject Player;
    Transform playerTransform;
    float dist;
    public bool isGreen;
    public GameObject top;
    public bool isOpen = false;
    public Animator anim;
    void Start()
    {
        anim = top.GetComponent<Animator>();
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
        Player = GameObject.Find("Player");
        playerTransform = Player.transform;  
        float dist = Vector3.Distance (playerTransform.position, transform.position);
        if(Input.GetKeyDown(KeyCode.E) && dist <= 3f && isGreen)
        {
            if(!isOpen)
            {
                ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
                im.GetComponent<ImageChange>().setWhite();

                top = GameObject.Find("Top");
                isOpen = true;
                top.GetComponent<Animator>().SetBool("isOpen", true);
            }
            else
            {
                ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
                im.GetComponent<ImageChange>().setWhite();
                top = GameObject.Find("Top");
                isOpen = false;
                top.GetComponent<Animator>().SetBool("isOpen", false);
            }
        }
    }
}
