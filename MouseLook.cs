using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float mouseSensitivity = 200f;
    public GameObject Crosshair;
    public Transform playerBody;
    float xRottion = 0f;
    public Camera cam;
    public GameObject WepCon;
    public GameObject Aim;
    public GameObject Aim_Rifle;
    public GameObject Aim_SMG;
    public GameObject Aim_Pistol;
    public GameObject SG20;
    public GameObject SMG5;
    public GameObject GL17;
    public GameObject PauseMenu;
    public GameObject DeathScreen;
    public float ZoomIn = 30.0f;
    public float ZoomOut = 65.0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam.fieldOfView = ZoomOut;
    }

    void Update()
    {
        if(Input.GetMouseButton(1) && PauseMenu.activeInHierarchy == false && DeathScreen.activeInHierarchy == false)
        {
          zoomingIn();
        }
        else zoomingOut();
       
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
       
        xRottion -= mouseY;
        xRottion = Mathf.Clamp(xRottion, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRottion, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
    public void zoomingIn()
    {
        cam.fieldOfView = ZoomIn;
        mouseSensitivity = 100.0f;
        Crosshair.SetActive(false);
        if(SG20.activeInHierarchy)
        {
            WepCon.transform.position = Aim_Rifle.transform.position;
        }

        else if(SMG5.activeInHierarchy)
        {
            WepCon.transform.position = Aim_SMG.transform.position;
        }

        else if(GL17.activeInHierarchy)
        {
            WepCon.transform.position = Aim_Pistol.transform.position;
        }
    }
    public void zoomingOut()
    {
        cam.fieldOfView = ZoomOut;
        WepCon.transform.position = Aim.transform.position;
        mouseSensitivity = 200.0f;
        Crosshair.SetActive(true);
    }
}