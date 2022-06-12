using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
public CharacterController Controller;
	public float speed;
	public float gravity = -9.81f;
	public float jumpHeight = 3f;
	public float Sprint = 16.0f;
	public float Walk = 6.0f;
	public GameObject PlayerModel;
	public Transform GroundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;
    public Camera mc;
	//public MouseLook mouseLook;
	public GameObject camPos1;
	public GameObject camPos2;
	bool isGrounded;
	Vector3 Velocity;


	void Awake()
	{
		//mouseLook = GameObject.Find("MainCamera").GetComponent<MouseLook>();
		speed = Walk;
	}

	void Update () 
	{
		isGrounded = Physics.CheckSphere (GroundCheck.position, groundDistance, groundMask);

		if (isGrounded && Velocity.y < 0) 
		{
			Velocity.y = -2f;
		}

		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		Controller.Move (move * speed * Time.deltaTime);

		if(Input.GetKey(KeyCode.LeftControl))
		{
			Crouching();
		}
		else Standing();

		if(Input.GetKey(KeyCode.LeftShift))
		{
			Running();
		}
		else Walking();

		if (Input.GetButtonDown ("Jump") && isGrounded) 
		{
			Velocity.y = Mathf.Sqrt (jumpHeight * -2f * gravity);
		}
		Velocity.y += gravity * Time.deltaTime;
		Controller.Move (Velocity * Time.deltaTime);
	}

	void Crouching()
	{
		mc.transform.position = camPos1.transform.position;
		PlayerModel.transform.localScale = new Vector3(1, 0.6f, 1);
		Controller.height = 1.2f;
	}

	void Standing()
	{
		mc.transform.position = camPos2.transform.position;
		PlayerModel.transform.localScale = new Vector3(1, 1, 1);
		Controller.height = 2.0f;
	}

	void Running()
	{
		//mouseLook.cam.fieldOfView = mouseLook.ZoomIn;
		speed = Sprint;
	}
	void Walking()
	{
		//mouseLook.cam.fieldOfView = mouseLook.ZoomOut;
		speed = Walk;
	}
}