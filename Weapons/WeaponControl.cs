using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
// In here we have "Weapons Game Objects" and then "Weapon Effects" and lastly "Weapon UI(Text&Icon)"
    
    public GameObject CAT9;
    public GameObject CAT9_Effects;
    public GameObject CAT9_Text;
    
    public GameObject EM107;
    public GameObject EM107_Effects;
    public GameObject EM107_Text;

    public GameObject SUP5;
    public GameObject SUP5_Effects;
    public GameObject SUP5_Text;

    public GameObject SUP7;
    public GameObject SUP7_Effects;
    public GameObject SUP7_Text;
    
    public GameObject FHD;
    public GameObject FHD_Effects;
    public GameObject FHD_Text;

    public GameObject GN17;
    public GameObject GN17_Effects;
    public GameObject GN17_Text;

    public GameObject FlashLight;
    public GameObject FlashLight_Icon;

    public GameObject Sensor;
    public GameObject Sensor_Icon;

    public GameObject diffuser;
    public GameObject diffuser_Icon;


    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public GameObject Slot4;

    public bool haveGun;
    public bool hasPistol = false;
    public bool hasSMG = false;
    public bool hasRifle = false;
    
    public AudioSource audio;
    
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
        else if(Input.GetKey("b"))
        {
            Diffuser();
        }

        if (EM107.activeInHierarchy)
        {
            haveGun = true;
			EM107_Text.SetActive (true);
        }
		else
        {
            haveGun = false;
            EM107_Text.SetActive (false);
        } 
        

		if (CAT9.activeInHierarchy)
        {
            haveGun = true;
            CAT9_Text.SetActive (true);
        }
		else
        {
            haveGun = false;
            CAT9_Text.SetActive (false);
        }

        if (SUP5.activeInHierarchy)
        {
            SUP5_Text.SetActive (true);
            haveGun = true;
        }
		else
        {
            SUP5_Text.SetActive (false);
            haveGun = false;
        } 

		if (SUP7.activeInHierarchy)
        {
            SUP7_Text.SetActive (true);
            haveGun = true;
        }
		else
        {
            SUP7_Text.SetActive (false);
            haveGun = false;
        }
        if (GN17.activeInHierarchy)
        {
            GN17_Text.SetActive (true);
            haveGun = true;
        }
		else
        {
            GN17_Text.SetActive (false);
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
            SUP5_Effects.SetActive(false);
            SUP7_Effects.SetActive(false);

            Slot3.SetActive(false);
            GN17_Effects.SetActive(false);
            FHD_Effects.SetActive(false);

            Slot4.SetActive(false);
            diffuser.SetActive(false);
        }
        public void input2()
        {
            Slot1.SetActive(false);
            EM107_Effects.SetActive(false);
            CAT9_Effects.SetActive(false);

            Slot2.SetActive(true);

            Slot3.SetActive(false);
            GN17_Effects.SetActive(false);
            FHD_Effects.SetActive(false);

            Slot4.SetActive(false);
            diffuser.SetActive(false);
        }
        public void input3()
        {
            Slot1.SetActive(false);
            EM107_Effects.SetActive(false);
            CAT9_Effects.SetActive(false);

            Slot2.SetActive(false);
            SUP5_Effects.SetActive(false);
            SUP7_Effects.SetActive(false);

            Slot3.SetActive(true);

            Slot4.SetActive(false);
            diffuser.SetActive(false);
        }
        public void input4()
        {
            Slot1.SetActive(false);
            EM107_Effects.SetActive(false);
            CAT9_Effects.SetActive(false);

            Slot2.SetActive(false);
            SUP5_Effects.SetActive(false);
            SUP7_Effects.SetActive(false);

            Slot3.SetActive(false);
            GN17_Effects.SetActive(false);
            FHD_Effects.SetActive(false);

            Slot4.SetActive(true);
            diffuser.SetActive(false);
        }
        public void Diffuser()
        {
            Slot1.SetActive(false);
            EM107_Effects.SetActive(false);
            CAT9_Effects.SetActive(false);

            Slot2.SetActive(false);
            SUP5_Effects.SetActive(false);
            SUP7_Effects.SetActive(false);

            Slot3.SetActive(false);
            GN17_Effects.SetActive(false);
            FHD_Effects.SetActive(false);

            Slot4.SetActive(false);

            diffuser.SetActive(true);
        }
}