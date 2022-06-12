using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject enemyActive;
	public GameObject enemyDeactive;
    ImageChange im;
    GameObject Player;
    Transform playerTransform;
    public float dist;
    public bool isGreen;

    Color colorStart = Color.red;
    Color colorEnd = Color.blue;
    float duration = 1f;
    Renderer rend;

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
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend = GetComponent<Renderer> ();
        rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
        GameObject Player = GameObject.Find("Player");
        playerTransform = Player.transform;
        float dist = Vector3.Distance (playerTransform.position, transform.position);
        if(Input.GetKey(KeyCode.E))
        {
            if(dist <= 3f)
            {
                if(isGreen)
                {
                    enemyActive.SetActive(true);
		            enemyDeactive.SetActive(false);
                }
            }
        }
    }
                
}
