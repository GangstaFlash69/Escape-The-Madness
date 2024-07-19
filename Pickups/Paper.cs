using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    ImageChange im;
    GameObject Player;
    Transform playerTransform;
    public float dist;
    public bool isGreen;
    private AudioSource Take;

    void Awake()
    {
        Take = GetComponent<AudioSource>();
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
        Debug.Log("You have picked up an objective paper!");
        Destroy(GetComponent<MeshCollider>());
        Destroy(GetComponent<MeshRenderer>());
        Take.Play();
        Destroy(gameObject, 3f);
    }
}
