using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Drop_GL23 : MonoBehaviour
{
    public GameObject weaponSpawn;
    public Transform spawnTransform;
    public GameObject weaponPref;
    public WeaponControl wc;
    public Shooting_Rifle sr;
    void Update()
    {
        if(Input.GetKey(KeyCode.G)&& gameObject != null && sr.isReloading == false)
        {
            GameObject weaponSpawn = GameObject.Find("Aim");
            spawnTransform = weaponSpawn.transform;

            GameObject weapon = Instantiate(weaponPref, spawnTransform.position, spawnTransform.rotation);
            weaponPref.GetComponent<Rigidbody>().velocity = transform.forward * 1;

            WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
            wc.GL23.SetActive (false);
            wc.GL23_Effects.SetActive (false);
        }
    }
}