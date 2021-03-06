﻿using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {

	public Transform spawnPoint;
	public GameObject Cannon1;
	//public float delay = 0.01f;
	public float force = 100f;
	Rigidbody2D rb;
	public float maxSpeed= 10f;
	Vector2 directionCannon;
	float coolDown = 0f;
    public float coolDownTime = .8f;
    public string fire;
	public AudioSource audioSource;


	void Start () 
	{
		audioSource = GetComponent<AudioSource>();

	}



	void Update() 
	{
		coolDown -= Time.deltaTime;
        
		if (Input.GetKeyDown (fire) && coolDown <= 0) {
			GameObject ballInstance;
			ballInstance = Instantiate (Cannon1, spawnPoint.transform.position, spawnPoint.rotation) as GameObject;
			rb = ballInstance.GetComponent<Rigidbody2D> ();
			directionCannon = rb.velocity + ((Vector2)transform.up * maxSpeed);
			rb.AddForce (-directionCannon * force);
			rb.velocity = transform.forward * maxSpeed;
			coolDown = coolDownTime;
			audioSource.Play ();

		}
		}



}
