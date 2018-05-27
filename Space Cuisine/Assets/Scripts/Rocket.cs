﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField] float rcsThrust = 100f; //Allows change in editor but not in other scripts
    [SerializeField] float mainThrust = 10f;

    Rigidbody rigidBody;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Thrust();
        Rotate();
	}

    private void Thrust()
    {
        float thrustThisFrame = mainThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame); // can rotate when thrusting. Use relative so acts on direction.
            if (!audioSource.isPlaying) audioSource.Play();
        }

        else audioSource.Stop();
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; //take manual control of physics rotation.

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))transform.Rotate(Vector3.forward * rotationThisFrame); // z axis rotate

        else if (Input.GetKey(KeyCode.D)) transform.Rotate(-Vector3.forward * rotationThisFrame);

        rigidBody.freezeRotation = false; //resume physics control of physics rotation.
    }


}
