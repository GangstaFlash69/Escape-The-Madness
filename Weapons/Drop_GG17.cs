using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_GG17 : MonoBehaviour
{
    public GameObject weaponSpawn;
    public Transform spawnTransform;
    public GameObject weaponPref;
    public WeaponControl wc;
    public Shooting_Pistol sp;
    void Update()
    {
        if(Input.GetKey(KeyCode.G) && gameObject != null && sp.isReloading == false)
        {
            GameObject weaponSpawn = GameObject.Find("Aim");
            spawnTransform = weaponSpawn.transform;
            GameObject weapon = Instantiate(weaponPref, spawnTransform.position, spawnTransform.rotation);
            weaponPref.GetComponent<Rigidbody>().velocity = transform.forward * 1;
            WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
            wc.GG17.SetActive (false);
            wc.GG17_Effects.SetActive (false);
        }
    }
}
