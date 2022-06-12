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
    public GameObject Weapon;
    public GameObject Aim1;
    public GameObject Aim2;
    public float ZoomIn = 30.0f;
    public float ZoomOut = 65.0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam.fieldOfView = ZoomOut;
    }

    void Update()
    {
        if(Input.GetMouseButton(1))
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
        Weapon.transform.position = Aim2.transform.position;
        Crosshair.SetActive(false);
    }
    public void zoomingOut()
    {
        cam.fieldOfView = ZoomOut;
        Weapon.transform.position = Aim1.transform.position;
        mouseSensitivity = 200.0f;
        Crosshair.SetActive(true);
    }
}