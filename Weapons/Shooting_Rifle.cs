using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Rifle : MonoBehaviour
{
    public GameObject BulletPref;
    public GameObject GunModel;
    public Camera cam;
    public bool IsShooting = false;
    public ParticleSystem Flare;
    public GameObject Effects;
    public Transform bulletSpawner;
    private int bulletSpeed = 5;
    public float firerate;
    public float nextBullet;
    Animator animator;
    public float ReloadTime = 2f;
    public bool isReloading = false;
    public bool isAimming = false;
    [SerializeField] private GameObject spikeEffect;
    public int Ammo;
    public int AmmoCarry;
    public int MaxAmmo;
    public int LeftAmmo = 0;
   //private AudioSource Audio;
    public AudioClip RifleShot;
    public AudioClip Reloading1;
    public AudioClip empty;
    public int Range;
    public int shotDamage;
   // private MeshRenderer target;
   // public LayerMask interactionlayer;
    public WeaponControl wc;
    public GameObject PauseMenu;
    public GameObject DeathScreen;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * Range);
       // Gizmos.DrawRay(transform.position, transform.forward * Range);
    }

    void Awake()
    {
        //Audio = GetComponent<AudioSource>();
        animator = GunModel.GetComponent<Animator>();
    }

    void Start()
    {
        WeaponControl wc = GameObject.Find("WeaponController").GetComponent<WeaponControl>();
        Ammo = MaxAmmo;
    }

    void OnEnable()
    {
        GunModel.GetComponent<Animator>().SetBool("isReloading", false);
        GunModel.GetComponent<Animator>().SetBool("Idle", true);
        GunModel.GetComponent<Animator>().SetBool("isAimming", false);
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time > nextBullet && isReloading == false)
        {
            if(Ammo > 0)
            {
                if(PauseMenu.activeInHierarchy == false && DeathScreen.activeInHierarchy == false)
                {
                /*if(isReloading == true)
                {
                    StopCoroutine(Reload());
                    isReloading = false;
                }*/
                Ammo--;
                LeftAmmo = 0;
                nextBullet = Time.time + firerate;
                GunModel.GetComponent<Animator>().SetBool("Idle", false);
                GameObject Bullet = Instantiate(BulletPref, bulletSpawner.position, bulletSpawner.rotation);
                Bullet.GetComponent<Rigidbody>().velocity = transform.right * bulletSpeed;
                RaycastHit hit;
               if(Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, Range))
               {
                 GameObject obj = Instantiate(spikeEffect, hit.point, Quaternion.LookRotation(hit.normal));
                 obj.transform.position += obj.transform.forward / 1000;
                 EnemyAiTutorial eh = hit.collider.GetComponent<EnemyAiTutorial> ();
			     if (eh != null) 
                 {
				   eh.TakeDamage (shotDamage);
                 }
                 EnemyHealth eh2 = hit.collider.GetComponent<EnemyHealth> ();
                 if (eh2 != null) 
                 {
				   eh2.GetHurt (shotDamage);
                 }
                    Target eh3 = hit.collider.GetComponent<Target> ();
                 if (eh3 != null) 
                 {
				   eh3.GetHit (shotDamage);
                 }
               }
                wc.audio.PlayOneShot(RifleShot);
                //Audio.pitch = Random.Range(1.0f, 1.1f);
                Effects.SetActive (true);
                Flare.Play();
                }
            }
            else if(Input.GetMouseButtonDown(0))
            wc.audio.PlayOneShot(empty);
        }
        else GunModel.GetComponent<Animator>().SetBool("Idle", true);

        if (Input.GetKeyDown(KeyCode.R) && Ammo < MaxAmmo && AmmoCarry != 0f && isReloading == false)
        {
            StartCoroutine(Reload());
            wc.audio.PlayOneShot(Reloading1);
            return;
        }
    }

    IEnumerator Reload()
    {
        GunModel.GetComponent<Animator>().SetBool("isReloading", true);
        isReloading = true;
        yield return new WaitForSeconds(ReloadTime);
        if(AmmoCarry < MaxAmmo)
        {
            if (Ammo + AmmoCarry <= MaxAmmo)
            {
                Ammo = Ammo + AmmoCarry;
            }
            else
            {
                Ammo = Ammo + AmmoCarry;
                LeftAmmo = Ammo - MaxAmmo;
                AmmoCarry = LeftAmmo;
                Ammo = MaxAmmo;
            }
            AmmoCarry = LeftAmmo;
        }
        else
        {
            AmmoCarry -= MaxAmmo;
            AmmoCarry += Ammo;
            Ammo = MaxAmmo;
        }
        //isReloading = false;
        GunModel.GetComponent<Animator>().SetBool("isReloading", false);
        isReloading = false;
    }
}