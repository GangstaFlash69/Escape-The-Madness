using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public TMP_Text timer_Text;
    public float timer;
    public bool disarmed;
    public bool start;
    public Bomb briefcase;
    WiresManager wm;

    void Start()
    {
        start = false;
        disarmed = false;
        timer = 60f;
    }
    void Update()
    {
        Bomb briefcase = GameObject.Find("Top").GetComponent<Bomb>();
        if(briefcase.isOpen == true)
        start = true;

        if (start == true)
        {
            if (!disarmed)
            {
                if(timer < 0f)
                {
                    Stop();
                    wm = GameObject.Find("Wires").GetComponent<WiresManager>();
                    wm.BlowUp();
                }
                else
                {
                    timer -= Time.deltaTime;
                    string minutes = ((int)timer / 60).ToString();
                    string seconds = (timer % 60).ToString("f2");
                    timer_Text.text = minutes + ":" + seconds;
                }
            }
        }
    }
    public void Stop()
    {
        timer = 0;
        disarmed = true;
    }
}