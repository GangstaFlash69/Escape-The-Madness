using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter_Pickup : MonoBehaviour, IInteractable
{
    public GameObject cutter;
    public AudioClip pickup;
    public string GetDescription()
    {
        return "Press E to pick up the Wires Cutter";
    }
 
    public void Interact()
    {
        cutter.SetActive (true);
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
        wc.audio.PlayOneShot(pickup);
        Destroy(gameObject);
    }
}