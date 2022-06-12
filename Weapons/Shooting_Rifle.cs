using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Rifle : MonoBehaviour
{
    public GameObject BulletPref;
    public bool IsShooting = false;
    public ParticleSystem Flare;
    public GameObject Effects;
    public Transform bulletSpawner;
    private int bulletSpeed = 5;
    public float firerate;
    public float nextBullet;
    public Animator animator;
    public float ReloadTime = 2f;
    [SerializeField] private GameObject spikeEffect;
    public int Ammo;
    public int AmmoLimit;
    public int MaxAmmo;
    public int LeftAmmo = 0;
    private AudioSource Audio;
    public AudioClip Reloading1;
    public int Range;
    public int shotDamage;
    private MeshRenderer target;
    public LayerMask interactionlayer;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * Range);
    }

    void Awake()
    {
        Audio = GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        Ammo = MaxAmmo;
    }

    void OnEnable()
    {
        animator.SetBool("isReloading", false);
       // animator.SetBool("Aiming", false);
        animator.SetBool("Idle", true);
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time > nextBullet && Ammo > 0)
        {
                Ammo--;
                LeftAmmo = 0;
                nextBullet = Time.time + firerate;
                animator.SetBool("Idle", false);
                GameObject Bullet = Instantiate(BulletPref, bulletSpawner.position, bulletSpawner.rotation);
                Bullet.GetComponent<Rigidbody>().velocity = -transform.right * bulletSpeed;
                RaycastHit hit;
               if(Physics.Raycast (transform.position, transform.forward, out hit, Range))
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
               }
                Audio.Play();
                Effects.SetActive (true);
                Flare.Play();
        }
        else animator.SetBool("Idle", true);

        if (Input.GetKeyDown(KeyCode.R) && Ammo < MaxAmmo && AmmoLimit != 0f)
        {
            StartCoroutine(Reload());
            Audio.PlayOneShot(Reloading1);
            return;
        }
    }

    IEnumerator Reload()
    {
        animator.SetBool("isReloading", true);
        yield return new WaitForSeconds(ReloadTime);
        if(AmmoLimit < MaxAmmo)
        {
            if (Ammo + AmmoLimit <= MaxAmmo)
            {
                Ammo = Ammo + AmmoLimit;
            }
            else
            {
                Ammo = Ammo + AmmoLimit;
                LeftAmmo = Ammo - MaxAmmo;
                AmmoLimit = LeftAmmo;
                Ammo = MaxAmmo;
            }
            AmmoLimit = LeftAmmo;
        }
        else
        {
            AmmoLimit -= MaxAmmo;
            AmmoLimit += Ammo;
            Ammo = MaxAmmo;
        }
        //isReloading = false;
        animator.SetBool("isReloading", false);
    }
}