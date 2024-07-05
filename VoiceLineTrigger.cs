using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLineTrigger : MonoBehaviour
{
   public AudioSource audio;
   public AudioClip clip1;
   public AudioClip clip2;
   public bool switchclip = false;
   public bool triggered = false;
   public bool finalclip;
   Collider col;
   void Start()
   {
    audio = gameObject.GetComponent<AudioSource>();
    col = gameObject.GetComponent<Collider>();
   }
    void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player" && triggered == false) 
		{
            if (switchclip == false)
            {
                audio.PlayOneShot(clip1);
                switchclip = true;
                triggered = true;
            }
            else
            {  audio.PlayOneShot(clip2);
               switchclip = false;
               triggered = true;
            }
        }
    }
    void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player" && triggered == true) 
		{
            triggered = false;
            if(finalclip == true)
            {
               col.enabled = !col.enabled;
            }
        }
    }
}