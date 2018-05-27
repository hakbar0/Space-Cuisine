﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

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
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up); // can rotate when thrusting. Use relative so acts on direction.
            if (!audioSource.isPlaying) audioSource.Play();
        }

        else audioSource.Stop();
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; //take manual control of physics rotation.

        if (Input.GetKey(KeyCode.A)) transform.Rotate(Vector3.forward); // z axis rotate

        else if (Input.GetKey(KeyCode.D)) transform.Rotate(-Vector3.forward);

        rigidBody.freezeRotation = false; //resume physics control of physics rotation.
    }


}
