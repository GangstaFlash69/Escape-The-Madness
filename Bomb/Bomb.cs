using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IInteractable
{
    WeaponControl wc;
    public bool isOpen;
    public bool isReady;
    Animator anim;
    AudioSource audio;
    public AudioClip openUp;
    public AudioClip beeb;
    public GameObject timer;
    void Start()
    {
        isOpen = false;
        isReady = false;
        timer.SetActive (true);
        anim = gameObject.GetComponent<Animator>();
        audio = GameObject.Find("Bomb_Audio").GetComponent<AudioSource>();
    }
    public string GetDescription()
    {
        if(!isOpen)
        {
            return "Press E to open the briefcase";
        }
        else
        {
            return "Press E to close the briefcase";
        }

    }
    public void Interact()
    {
        if(!isOpen)
        {
            isOpen = true;
            isReady = true;
            gameObject.GetComponent<Animator>().SetBool("isOpen", true);
            audio.PlayOneShot(openUp);
        }
        else
        {
            isOpen = false;
            gameObject.GetComponent<Animator>().SetBool("isOpen", false);
            audio.PlayOneShot(openUp);
        }
        if(isReady == true)
        {
            audio.Play();
        }
    }
}