using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_SUP5 : MonoBehaviour
{
    public GameObject weaponSpawn;
    public Transform spawnTransform;
    public GameObject weaponPref;
    public WeaponControl wc;
    public Shooting_SMG ss;
    void Update()
    {
        if(Input.GetKey(KeyCode.G)&& gameObject != null && ss.isReloading == false)
        {
            GameObject weaponSpawn = GameObject.Find("Aim");
            spawnTransform = weaponSpawn.transform;

            GameObject weapon = Instantiate(weaponPref, spawnTransform.position, spawnTransform.rotation);
            weaponPref.GetComponent<Rigidbody>().velocity = transform.forward * 1;

            WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
            wc.SUP5.SetActive (false);
            wc.SUP5_Effects.SetActive (false);
            wc.hasSMG = false;
        }
    }
}
