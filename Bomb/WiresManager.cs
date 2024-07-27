using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresManager : MonoBehaviour
{
    public float disarmCode;
    public float startNumber;
    public float answer;
    public bool isRed;
    public bool isBlue;
    public bool isYellow;
    public bool isGreen;
    public bool isBlack;
    public bool isWhite;
    public int module;
    public int model;
    public Timer timer;
    AudioSource audio;
    public AudioClip boom;
    public AudioClip disarmed;

    void Start ()
    {
        isRed = false;
        isBlue = false;
        isYellow = false;
        isGreen = false;
        isBlack = false;
        isWhite = false;
        answer = startNumber;
        audio = GameObject.Find("Bomb_Audio").GetComponent<AudioSource>();
    }
        public void BlowUp()
    {
        Timer timer = GameObject.Find("Timer_Text").GetComponent<Timer>();
        timer.timer_Text.text = "B00M";
        timer.Stop();
        audio.PlayOneShot(boom);

        Debug.Log("BOOM!");
    }
    void Disarm()
    {
        Timer timer = GameObject.Find("Timer_Text").GetComponent<Timer>();
        timer.timer_Text.text = "Disarmed";
        timer.Stop();
        audio.PlayOneShot(disarmed);

        Debug.Log("Bomb has been disarmed!");
    }
    void Reset()
    {
        isRed = false;
        isBlue = false;
        isYellow =false;
        answer = 0f;
    }
    void Update()
    {
        //Start Number: 4 // Disarm Code: 1
        if(module == 1)
        {
            if(isRed)
            {
                if(isBlue)
                {
                    if(isYellow)
                    {
                        if(answer != disarmCode)
                        {
                            BlowUp();
                            Reset();
                        }
                        else
                        {
                            Disarm();
                            Reset();
                        }
                    }
                }
            }
        }
        //Start Number: 4 // Disarm Code: 2
        if(module == 2)
        {
            if (isRed)
            {
                if(isWhite)
                {
                    if(isBlack)
                    {
                        if(answer != disarmCode)
                        {
                            BlowUp();
                            Reset();
                        }
                        else
                        {
                            Disarm();
                            Reset();
                        }
                    }
                }
            }
        }
        //Start Number: 5 // Disarm Code: 4
        if (module == 3)
        {
            if(isGreen)
            {
                if(isBlack)
                {
                    if(isYellow)
                    {
                        if(answer != disarmCode)
                        {
                            BlowUp();
                            Reset();
                        }
                        else
                        {
                            Disarm();
                            Reset();
                        }   
                    }
                }
            }
        }
    }
}