﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
// In here we have "Weapons Game Objects" and then "Weapon Effects" and lastly "Weapon UI(Text&Icon)"
    
    public GameObject GL23;
    public GameObject GL23_Effects;
    public GameObject GL23_Text;
    
    public GameObject CT22;
    public GameObject CT22_Effects;
    public GameObject CT22_Text;

    public GameObject GT7s;
    public GameObject GT7s_Effects;
    public GameObject GT7s_Text;

    public GameObject GT8;
    public GameObject GT8_Effects;
    public GameObject GT8_Text;
    
    public GameObject FHD;
    public GameObject FHD_Effects;
    public GameObject FHD_Text;

    public GameObject GG17;
    public GameObject GG17_Effects;
    public GameObject GG17_Text;

    public GameObject FlashLight;
    public GameObject FlashLight_Icon;


    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public GameObject Slot4;

    public bool haveGun;

    void Update()
    {
        if (Input.GetKey (KeyCode.Alpha1)) 
		{
            input1();
        }
         else if (Input.GetKey (KeyCode.Alpha2)) 
		{
            input2();
        }
        else if (Input.GetKey (KeyCode.Alpha3)) 
		{
          input3();
        }
        else if(Input.GetKey(KeyCode.Alpha4))
        {
            input4();
        }

        if (CT22.activeInHierarchy)
        {
            haveGun = true;
			CT22_Text.SetActive (true);
        }
		else
        {
            haveGun = false;
            CT22_Text.SetActive (false);
        } 
        

		if (GL23.activeInHierarchy)
        {
            haveGun = true;
            GL23_Text.SetActive (true);
        }
		else
        {
            haveGun = false;
            GL23_Text.SetActive (false);
        }

        if (GT7s.activeInHierarchy)
        {
            GT7s_Text.SetActive (true);
            haveGun = true;
        }
		else
        {
            GT7s_Text.SetActive (false);
            haveGun = false;
        } 

		if (GT8.activeInHierarchy)
        {
            GT8_Text.SetActive (true);
            haveGun = true;
        }
		else
        {
            GT8_Text.SetActive (false);
            haveGun = false;
        }
        if (GG17.activeInHierarchy)
        {
            GG17_Text.SetActive (true);
            haveGun = true;
        }
		else
        {
            GG17_Text.SetActive (false);
            haveGun = false;
        }
        if (FHD.activeInHierarchy)
        {
            FHD_Text.SetActive (true);
            haveGun = true;
        }
		else
        {
            FHD_Text.SetActive (false);
            haveGun = false;
        }
        
    }
        public void input1()
        {
            Slot1.SetActive(true);

            Slot2.SetActive(false);
            GT7s_Effects.SetActive(false);
            GT8_Effects.SetActive(false);

            Slot3.SetActive(false);
            GG17_Effects.SetActive(false);
            FHD_Effects.SetActive(false);

            Slot4.SetActive(false);
        }
        public void input2()
        {
            Slot1.SetActive(false);
            CT22_Effects.SetActive(false);
            GL23_Effects.SetActive(false);

            Slot2.SetActive(true);

            Slot3.SetActive(false);
            GG17_Effects.SetActive(false);
            FHD_Effects.SetActive(false);

            Slot4.SetActive(false);
        }
        public void input3()
        {
            Slot1.SetActive(false);
            CT22_Effects.SetActive(false);
            GL23_Effects.SetActive(false);

            Slot2.SetActive(false);
            GT7s_Effects.SetActive(false);
            GT8_Effects.SetActive(false);

            Slot3.SetActive(true);

            Slot4.SetActive(false);
        }
        public void input4()
        {
            Slot1.SetActive(false);
            CT22_Effects.SetActive(false);
            GL23_Effects.SetActive(false);

            Slot2.SetActive(false);
            GT7s_Effects.SetActive(false);
            GT8_Effects.SetActive(false);

            Slot3.SetActive(false);
            GG17_Effects.SetActive(false);
            FHD_Effects.SetActive(false);

            Slot4.SetActive(true);
        }
}