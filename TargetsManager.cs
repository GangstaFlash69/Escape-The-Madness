using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsManager : MonoBehaviour
{
    public int total = 0;
    public AudioSource aduio;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public Animator anim;
    public Animator anim2;
    public Animator anim3;
    public GameObject gate1;
    public GameObject gate2;
    public GameObject gate3;
    void Start()
    {
        anim = gate1.GetComponent<Animator>();
        anim2 = gate2.GetComponent<Animator>();
        anim3 = gate3.GetComponent<Animator>();
    }
    void Update()
    {
        if( total == 3)
        {
            total ++;
            aduio.PlayOneShot(clip1);
            aduio.PlayOneShot(clip4);
            gate1.GetComponent<Animator>().SetBool("ButtonTriggered", true);

        }
        if( total == 7)
        {
            total ++;
            aduio.PlayOneShot(clip2);
            aduio.PlayOneShot(clip4);
            gate2.GetComponent<Animator>().SetBool("ButtonTriggered", true);
        }
        if( total == 11)
        {
            total ++;
            aduio.PlayOneShot(clip3);
            aduio.PlayOneShot(clip4);
            gate3.GetComponent<Animator>().SetBool("ButtonTriggered", true);
        }
    }
}
