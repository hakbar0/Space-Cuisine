﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space)) rigidBody.AddRelativeForce(Vector3.up); // can rotate when thrusting. Use relative so acts on direction.

        if (Input.GetKey(KeyCode.A)) transform.Rotate(Vector3.forward); // z axis rotate

        else if (Input.GetKey(KeyCode.D)) transform.Rotate(-Vector3.forward);
    }
}