using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_FT5 : MonoBehaviour
{
    GameObject weaponSpawn;
    Transform spawnTransform;
    public GameObject weaponPref;
    WeaponControl wc;

    void Update()
    {
        if(Input.GetKey(KeyCode.G) && gameObject != null)
        {
            GameObject weaponSpawn = GameObject.Find("Aim1");
            spawnTransform = weaponSpawn.transform;
            GameObject weapon = Instantiate(weaponPref, spawnTransform.position, spawnTransform.rotation);
            weaponPref.GetComponent<Rigidbody>().velocity = transform.forward * 1;
            WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
            wc.FT5.SetActive (false);
            wc.FT5_Effects.SetActive (false);
        }
    }
}
