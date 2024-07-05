using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_GT7s : MonoBehaviour
{
    public GameObject weaponSpawn;
    public Transform spawnTransform;
    public GameObject weaponPref;
    public WeaponControl wc;
    public Shooting_SMG ssmg;
    void Update()
    {
        if(Input.GetKey(KeyCode.G)&& gameObject != null && ssmg.isReloading == false)
        {
            GameObject weaponSpawn = GameObject.Find("Aim");
            spawnTransform = weaponSpawn.transform;

            GameObject weapon = Instantiate(weaponPref, spawnTransform.position, spawnTransform.rotation);
            weaponPref.GetComponent<Rigidbody>().velocity = transform.forward * 1;

            WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
            wc.GT7s.SetActive (false);
            wc.GT7s_Effects.SetActive (false);
        }
    }
}
