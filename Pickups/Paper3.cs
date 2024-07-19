using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper3 : MonoBehaviour
{
    ImageChange im;
    GameObject Player;
    public GameObject Wall;
    Transform playerTransform;
    public float dist;
    public bool isGreen;
    private AudioSource LittleGirlVoice;
    public GameObject Spawner;

    void Awake()
    {
        LittleGirlVoice = GetComponent<AudioSource>();
	}

    void OnMouseEnter()
    {
        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>();
        im.GetComponent<ImageChange>().setGreen();
        isGreen = true;
    }
    void OnMouseExit()
    {
        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>();
        im.GetComponent<ImageChange>().setWhite();
        isGreen = false;
    }
    void Update()
    {  
        Player = GameObject.Find("Player");
        playerTransform = Player.transform;
        float dist = Vector3.Distance (playerTransform.position, transform.position);
        if(Input.GetKey(KeyCode.E))
        {
            if(dist <= 3f)
            {
                if(isGreen)
                {
                    pickup();
                }
            }
        }
    }
    void pickup()
    {
        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
        im.GetComponent<ImageChange>().setWhite();
        Debug.Log("You have picked up a white paper!");
        Spawner.SetActive(true);
        Destroy(Wall);
        Destroy(GetComponent<MeshCollider>());
        Destroy(GetComponent<MeshRenderer>());
        LittleGirlVoice.Play();
        Destroy(gameObject, 10);
    }
}
