using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlay : MonoBehaviour
{
    ImageChange im;
    GameObject Player;
    public GameObject Wall;
    Transform playerTransform;
    public float dist;
    public bool isGreen;
    public AudioSource Audio;
    public AudioClip DoorOpen;
    public AudioClip VoiceLine;
    public Animator anim;
    public bool ButtonTriggered = false;

    void Awake()
    {
        Audio = GetComponent<AudioSource>();
        anim = Wall.GetComponent<Animator>();
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
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(dist <= 3f)
            {
                if(isGreen)
                {
                    trigger();
                }
            }
        }
    }
    void trigger()
    {
        ImageChange im = GameObject.Find("Crosshair").GetComponent<ImageChange>(); 
        im.GetComponent<ImageChange>().setWhite();
        Debug.Log("You have clicked the button to open the door");

        Audio.PlayOneShot(DoorOpen);
        Audio.PlayOneShot(VoiceLine);
        Wall.GetComponent<Animator>().SetBool("ButtonTriggered", true);

        Destroy(GetComponent<MeshCollider>());
        Destroy(GetComponent<MeshRenderer>());
        Destroy(Wall, 9);
    }
}
