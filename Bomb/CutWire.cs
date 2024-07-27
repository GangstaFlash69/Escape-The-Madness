using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutWire : MonoBehaviour, IInteractable
{
    WeaponControl wc;
    public WiresManager wm;
    public bool isEquipped = false;
    AudioSource audio;
    public AudioClip cutAudio;
    public string GetDescription() 
    {
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
        if(wc.cutter.activeInHierarchy)
        {
            isEquipped = true;
            return "Press E to cut the wire";
        }
        return "Cutter must be equipped";
    }
    public void Interact()
    {
        if(isEquipped == true)
        {
            //WiresManager wm = GameObject.Find("Wires").GetComponent<WiresManager>();
            if(gameObject.name.Equals ("RedWire"))
            {
                wm.answer = wm.answer - 2;
                wm.isRed = true;
            }
            else if(gameObject.name.Equals("BlueWire"))
            {
                wm.answer = wm.answer * 2;
                wm.isBlue = true;
            }
            else if (gameObject.name.Equals("YellowWire"))
            {
                wm.answer = wm.answer / 4;
                wm.isYellow = true;
            }
            else if(gameObject.name.Equals("GreenWire"))
            {
                wm.answer = wm.answer * 3;
                wm.isGreen = true;
            }
            else if(gameObject.name.Equals("BlackWire"))
            {
                wm.answer = wm.answer + 1;
                wm.isBlack = true;
            }
            else if(gameObject.name.Equals("WhiteWire"))
            {
                wm.answer = wm.answer / 2;
                wm.isWhite = true;
            }
            audio = GameObject.Find("Bomb_Audio").GetComponent<AudioSource>();
            audio.PlayOneShot(cutAudio);
            Destroy(gameObject);
        }
    }
}